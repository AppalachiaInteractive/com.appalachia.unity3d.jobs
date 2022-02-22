#region

using System;
using Appalachia.Core.Collections.Native;
using Appalachia.Core.Execution;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using Random = Unity.Mathematics.Random;

#endregion

namespace Appalachia.Jobs.Optimization.Utilities
{
    public struct JobRandoms : IDisposable
    {
        #region Constants and Static Readonly

        public const int INSTANCE_COUNT = 50000;

        #endregion

        #region Fields and Autoproperties

        private NativeArray<double> randoms;

        private Random random;

        #endregion

        public bool IsCreated => randoms.IsCreated;

        public static JobRandoms Create(Allocator allocator)
        {
            using (_PRF_Create.Auto())
            {
                var instance = new JobRandoms();

                instance.randoms = new NativeArray<double>(INSTANCE_COUNT, allocator);

                instance.random = new Random((uint)GLOBAL_RANDOM.random.Next(0, int.MaxValue));

                CleanupManager.Store(ref instance);

                var job = new PopulateJob { random = instance.random, randoms = instance.randoms };

                job.Execute();

                return instance;
            }
        }

        public double Get(int index)
        {
            return randoms[index % randoms.Length];
        }

        public bool ShouldAllocate()
        {
            return randoms.ShouldAllocate();
        }

        #region IDisposable Members

        /*public void Dispose(JobHandle deps)
        {
            if (randoms.IsCreated)
            {
                randoms.Dispose(deps);          
            }
            
        }*/
        public void Dispose()
        {
            if (randoms.IsCreated)
            {
                randoms.SafeDispose();
            }
        }

        #endregion

        #region Nested type: PopulateJob

        [BurstCompile]
        private struct PopulateJob : IJob
        {
            #region Fields and Autoproperties

            [WriteOnly] public NativeArray<double> randoms;
            public Random random;

            #endregion

            #region IJob Members

            public void Execute()
            {
                for (var i = 0; i < randoms.Length; i++)
                {
                    randoms[i] = random.NextDouble();
                }
            }

            #endregion
        }

        #endregion

        #region Profiling

        private const string _PRF_PFX = nameof(JobRandoms) + ".";

        private static readonly ProfilerMarker _PRF_Create = new ProfilerMarker(_PRF_PFX + nameof(Create));

        #endregion
    }
}
