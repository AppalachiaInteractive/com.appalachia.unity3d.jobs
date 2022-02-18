#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Appalachia.Core.Attributes;
using Appalachia.Core.Collections.Native;
using Appalachia.Core.Math.Stats.Implementations;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Strings;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;

#endregion

namespace Appalachia.Jobs.Concurrency
{
    [NonSerializable]
    public class JobCycleQueueManager : AppalachiaSimpleBase, IDisposable
    {
        public JobCycleQueueManager()
        {
            JobTracker.ReigsterQueueManagerForDisposal(this);
        }

        #region Fields and Autoproperties

        [NonSerialized] private Queue<int> _active;
        [NonSerialized] private Queue<int> _completed;

        [NonSerialized] private string _countString;
        [NonSerialized] private long[] _cycleTimings;
        [NonSerialized] private Queue<int> _delayed;
        [NonSerialized] private double _fastestCycleTime;

        [NonSerialized] private NativeList<JobHandle> _handles;

        [NonSerialized] private Queue<int> _inactive;

        [NonSerialized] private JobCycleStatus[] _status;
        [NonSerialized] private Queue<int> _swap;

        [NonSerialized] private bool[] _timeTracked;
        [NonSerialized] private doubleStatsTracker _timeTracker;

        [NonSerialized] private string _timingString;

        #endregion

        public bool AnyActive => _active.Count > 0;
        public bool AnyCompleted => _completed.Count > 0;

        public bool AnyInactive => _inactive.Count > 0;

        public bool RequiresPopulation => _handles.ShouldAllocate();

        public doubleStatsTracker TimeTracker
        {
            get
            {
                if (_timeTracker == null)
                {
                    _timeTracker = new doubleStatsTracker();
                }

                return _timeTracker;
            }
        }

        public int ActiveCount => _active.Count;
        public int CompletedCount => _completed.Count;
        public int DelayedCount => _delayed.Count;

        public int InactiveCount => _inactive.Count;
        public int NextCompleted => AnyCompleted ? _completed.Peek() : -1;

        public int NextInactive => AnyInactive ? _inactive.Peek() : -1;

        /// <inheritdoc />
        [DebuggerStepThrough]
        public override string ToString()
        {
            using (_PRF_ToString.Auto())
            {
                return CountsString();
            }
        }

        public void CheckTiming()
        {
            using (_PRF_CheckTiming.Auto())
            {
                DateTime utcNow;

                using (_PRF_CheckTiming_UTCNow.Auto())
                {
                    utcNow = DateTime.UtcNow;
                }

                var length = _status.Length;

                for (var i = 0; i < length; i++)
                {
                    JobCycleStatus status;

                    using (_PRF_CheckTiming_GetStatus.Auto())
                    {
                        status = _status[i];
                    }

                    bool shouldCheckTime;

                    using (_PRF_CheckTiming_Conditional.Auto())
                    {
                        bool CheckTiming_Conditional_Status()
                        {
                            using (_PRF_CheckTiming_Conditional_Status.Auto())
                            {
                                return status == JobCycleStatus.Active;
                            }
                        }

                        bool CheckTiming_Conditional_TimeTracked()
                        {
                            using (_PRF_CheckTiming_Conditional_TimeTracked.Auto())
                            {
                                return !_timeTracked[i];
                            }
                        }

                        bool CheckTiming_Conditional_Completed()
                        {
                            using (_PRF_CheckTiming_Conditional_Completed.Auto())
                            {
                                return _handles[i].IsCompleted;
                            }
                        }

                        shouldCheckTime = CheckTiming_Conditional_Status() &&
                                          CheckTiming_Conditional_TimeTracked() &&
                                          CheckTiming_Conditional_Completed();
                    }

                    if (shouldCheckTime)
                    {
                        double currentCycleTime;

                        using (_PRF_CheckTiming_GetCycleTime.Auto())
                        {
                            currentCycleTime = CurrentCycleTime(i, utcNow);
                        }

                        using (_PRF_CheckTiming_Track.Auto())
                        {
                            _timeTracker.Track(currentCycleTime);
                            _timeTracked[i] = true;
                        }
                    }
                }
            }
        }

        public void CheckWork()
        {
            using (_PRF_CheckWork.Auto())
            {
                var utcNow = DateTime.UtcNow;

                while (_delayed.Count > 0)
                {
                    var i = _delayed.Dequeue();

                    var duration = CurrentCycleTime(i, utcNow);

                    if (duration < _fastestCycleTime)
                    {
                        _status[i] = JobCycleStatus.Delayed;
                        _swap.Enqueue(i);
                    }
                    else
                    {
                        _status[i] = JobCycleStatus.Inactive;
                        _inactive.Enqueue(i);
                    }
                }

                var temp = _delayed;
                _delayed = _swap;
                _swap = temp;

                while (_active.Count > 0)
                {
                    var i = _active.Dequeue();

                    var handle = _handles[i];

                    var complete = handle.IsCompleted;

                    if (complete)
                    {
                        _status[i] = JobCycleStatus.Completed;
                        _completed.Enqueue(i);

                        if (!_timeTracked[i])
                        {
                            _timeTracker.Track(CurrentCycleTime(i, utcNow));
                            _timeTracked[i] = true;
                        }
                    }
                    else
                    {
                        _status[i] = JobCycleStatus.Active;
                        _swap.Enqueue(i);
                    }
                }

                temp = _active;
                _active = _swap;
                _swap = temp;
            }
        }

        public string CountsString()
        {
            using (_PRF_CountsString.Auto())
            {
                return ZString.Format(
                    "Inactive {0} | Active {1} | Complete {2} | Delayed {3}",
                    InactiveCount,
                    ActiveCount,
                    CompletedCount,
                    DelayedCount
                );
            }
        }

        public void EnsureCompleted(int i)
        {
            using (_PRF_EnsureCompleted.Auto())
            {
                _handles[i].Complete();
            }
        }

        public void ForceCompleteAll()
        {
            using (_PRF_ForceCompleteAll.Auto())
            {
                if (!_handles.ShouldAllocate())
                {
                    JobHandle.CompleteAll(_handles);
                }

                var utcNow = DateTime.UtcNow;

                while (_active.Count > 0)
                {
                    var i = _active.Dequeue();
                    _status[i] = JobCycleStatus.Completed;
                    _completed.Enqueue(i);
                    _timeTracker.Track(CurrentCycleTime(i, utcNow));
                }
            }
        }

        public void Populate(int count, double fastestCycleTime = 3.0)
        {
            using (_PRF_Populate.Auto())
            {
                if (_timeTracker == null)
                {
                    _timeTracker = new doubleStatsTracker();
                }

                _fastestCycleTime = fastestCycleTime;
                _cycleTimings = new long[count];
                _timeTracked = new bool[count];
                _status = new JobCycleStatus[count];
                _inactive = new Queue<int>(count);
                _active = new Queue<int>(count);
                _completed = new Queue<int>(count);
                _swap = new Queue<int>(count);
                _delayed = new Queue<int>(count);
                _handles = new NativeList<JobHandle>(count, Allocator.Persistent) { Length = count };

                for (var i = 0; i < count; i++)
                {
                    _inactive.Enqueue(i);
                    _status[i] = JobCycleStatus.Inactive;
                }
            }
        }

        public void ResetCompleted(int i)
        {
            using (_PRF_ResetCompleted.Auto())
            {
                var next = _completed.Peek();

                if (i != next)
                {
                    throw new NotSupportedException(
                        ZString.Format(
                            "Incorrect job order. [{0}] was queued but [{1}] was next completed.",
                            i,
                            next
                        )
                    );
                }

                _completed.Dequeue();

                var duration = CurrentCycleTime(i, DateTime.UtcNow);

                if (duration < _fastestCycleTime)
                {
                    _status[i] = JobCycleStatus.Delayed;
                    _delayed.Enqueue(i);
                }
                else
                {
                    _status[i] = JobCycleStatus.Inactive;
                    _inactive.Enqueue(i);
                }
            }
        }

        public void SetActive(int i, JobHandle handle)
        {
            using (_PRF_SetActive.Auto())
            {
                var next = _inactive.Peek();

                if (i != next)
                {
                    throw new NotSupportedException(
                        ZString.Format(
                            "Incorrect job order. [{0}] was queued but [{1}] was next inactive.",
                            i,
                            next
                        )
                    );
                }

                _cycleTimings[i] = DateTime.Now.ToFileTimeUtc();
                _status[i] = JobCycleStatus.Active;
                _timeTracked[i] = false;
                _inactive.Dequeue();
                _active.Enqueue(i);
                _handles[i] = handle;
            }
        }

        public void Skip(int i, double padDelay = 5.0)
        {
            using (_PRF_Skip.Auto())
            {
                var next = _inactive.Peek();

                if (i != next)
                {
                    throw new NotSupportedException(
                        ZString.Format(
                            "Incorrect job order. [{0}] was skipped but [{1}] was next inactive.",
                            i,
                            next
                        )
                    );
                }

                _cycleTimings[i] = DateTime.Now.AddSeconds(padDelay).ToFileTimeUtc();
                _status[i] = JobCycleStatus.Delayed;
                _inactive.Dequeue();
                _delayed.Enqueue(i);
            }
        }

        public string TimingsString()
        {
            using (_PRF_TimingsString.Auto())
            {
                return ZString.Format(
                    "Average {0:F2}ms | Min {1:F2}ms | Max {2:F2}ms",
                    _timeTracker.Average,
                    _timeTracker.Minimum,
                    _timeTracker.Maximum
                );
            }
        }

        private double CurrentCycleTime(int i, DateTime utcNow)
        {
            using (_PRF_CurrentCycleTime.Auto())
            {
                var cycleStart = _cycleTimings[i];

                var cycleTime = DateTime.FromFileTimeUtc(cycleStart);

                var difference = utcNow - cycleTime;

                var duration = difference.TotalMilliseconds;

                return duration;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            using (_PRF_Dispose.Auto())
            {
                _handles.SafeDisposeAll();
            }
        }

        #endregion

        #region Profiling

        private const string _PRF_PFX = nameof(JobCycleQueueManager) + ".";
        private static readonly ProfilerMarker _PRF_Dispose = new(_PRF_PFX + nameof(Dispose));
        private static readonly ProfilerMarker _PRF_Populate = new(_PRF_PFX + nameof(Populate));
        private static readonly ProfilerMarker _PRF_Skip = new(_PRF_PFX + nameof(Skip));
        private static readonly ProfilerMarker _PRF_SetActive = new(_PRF_PFX + nameof(SetActive));
        private static readonly ProfilerMarker _PRF_EnsureCompleted = new(_PRF_PFX + nameof(EnsureCompleted));
        private static readonly ProfilerMarker _PRF_ResetCompleted = new(_PRF_PFX + nameof(ResetCompleted));
        private static readonly ProfilerMarker _PRF_CheckTiming = new(_PRF_PFX + nameof(CheckTiming));

        private static readonly ProfilerMarker _PRF_CheckWork = new(_PRF_PFX + nameof(CheckWork));

        private static readonly ProfilerMarker _PRF_ForceCompleteAll =
            new(_PRF_PFX + nameof(ForceCompleteAll));

        private static readonly ProfilerMarker _PRF_CurrentCycleTime =
            new(_PRF_PFX + nameof(CurrentCycleTime));

        private static readonly ProfilerMarker _PRF_ToString = new(_PRF_PFX + nameof(ToString));
        private static readonly ProfilerMarker _PRF_CountsString = new(_PRF_PFX + nameof(CountsString));
        private static readonly ProfilerMarker _PRF_TimingsString = new(_PRF_PFX + nameof(TimingsString));

        private static readonly ProfilerMarker _PRF_CheckTiming_UTCNow =
            new(_PRF_PFX + nameof(CheckTiming) + ".UTCNow");

        private static readonly ProfilerMarker _PRF_CheckTiming_GetStatus =
            new(_PRF_PFX + nameof(CheckTiming) + ".GetStatus");

        private static readonly ProfilerMarker _PRF_CheckTiming_GetCycleTime =
            new(_PRF_PFX + nameof(CheckTiming) + ".GetCycleTime");

        private static readonly ProfilerMarker _PRF_CheckTiming_Conditional =
            new(_PRF_PFX + nameof(CheckTiming) + ".Conditional");

        private static readonly ProfilerMarker _PRF_CheckTiming_Conditional_Status =
            new(_PRF_PFX + nameof(CheckTiming) + ".Conditional.Status");

        private static readonly ProfilerMarker _PRF_CheckTiming_Conditional_TimeTracked =
            new(_PRF_PFX + nameof(CheckTiming) + ".Conditional.TimeTracked");

        private static readonly ProfilerMarker _PRF_CheckTiming_Conditional_Completed =
            new(_PRF_PFX + nameof(CheckTiming) + ".Conditional.Completed");

        private static readonly ProfilerMarker _PRF_CheckTiming_Track =
            new(_PRF_PFX + nameof(CheckTiming) + ".Track");

        #endregion
    }
}
