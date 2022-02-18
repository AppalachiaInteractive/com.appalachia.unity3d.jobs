#region

using System;
using Appalachia.Core.Collections.Native;
using Appalachia.Core.Execution;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Random = Unity.Mathematics.Random;

#endregion

namespace Appalachia.Jobs.Optimization.Utilities
{
    public struct JobRandoms : IDisposable
    {
        #region Constants and Static Readonly

        public const int INSTANCE_COUNT = 50000;

        #endregion

        public JobRandoms(Allocator allocator)
        {
            randoms = new NativeArray<double>(INSTANCE_COUNT, allocator);

            random = new Random((uint)GLOBAL_RANDOM.random.Next(0, int.MaxValue));

            CleanupManager.Store(this);

            var job = new PopulateJob { random = random, randoms = randoms };

            job.Execute();
        }

        #region Fields and Autoproperties

        private readonly Random random;

        private NativeArray<double> randoms;

        #endregion

        public bool IsCreated => randoms.IsCreated;

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
    }
}
