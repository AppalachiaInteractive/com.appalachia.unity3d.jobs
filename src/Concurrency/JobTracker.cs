#region

using System.Collections.Generic;
using Appalachia.Core.Attributes;
using Appalachia.Core.Collections.NonSerialized;
using Unity.Jobs;

#endregion

namespace Appalachia.Jobs.Concurrency
{
    public static class JobTracker
    {
        private static List<JobCycleQueueManager> _queueManagers = new List<JobCycleQueueManager>();
        
        private const int _initialJob = 32;

        private static NonSerializedAppaLookup<string, JobHandle> _jobs;

        [ExecuteOnEnable]
        static void Initialize()
        {
            _jobs = new NonSerializedAppaLookup<string, JobHandle>();
        }

        public static void Track(string jobName, JobHandle handle)
        {
            if (_jobs == null)
            {
                _jobs = new NonSerializedAppaLookup<string, JobHandle>();
            }

            if (!_jobs.ContainsKey(jobName))
            {
                _jobs.Add(jobName, new JobHandle());
            }

            var masterHandle = _jobs[jobName];

            _jobs[jobName] = JobHandle.CombineDependencies(masterHandle, handle);
        }

        public static void CompleteAll(string jobName)
        {
            if (_jobs == null)
            {
                _jobs = new NonSerializedAppaLookup<string, JobHandle>();
                return;
            }

            if (_jobs.ContainsKey(jobName))
            {
                var handle = _jobs[jobName];

                handle.Complete();

                _jobs[jobName] = handle;
            }
        }

        public static bool AreAllJobsCompleted(string jobName)
        {
            if (_jobs == null)
            {
                _jobs = new NonSerializedAppaLookup<string, JobHandle>();
            }

            if (_jobs.ContainsKey(jobName))
            {
                var handle = _jobs[jobName];

                return handle.IsCompleted;
            }

            return true;
        }

        public static void ReigsterQueueManagerForDisposal(JobCycleQueueManager queueManager)
        {
            if (_queueManagers == null)
            {
                _queueManagers = new List<JobCycleQueueManager>();
            }
            
            _queueManagers.Add(queueManager);
        }
        
        [ExecuteOnDisable]
        public static void Dispose()
        {
            if (_jobs != null)
            {
                for (var i = 0; i < _jobs.Count; i++)
                {
                    _jobs.at[i].Complete();
                }

                _jobs.Clear();
            }

            if (_queueManagers != null)
            {
                for (var i = 0; i < _queueManagers.Count; i++)
                {
                    var queueManager = _queueManagers[i];

                    queueManager?.Dispose();
                }

                _queueManagers.Clear();
            }
        }
    }
}
