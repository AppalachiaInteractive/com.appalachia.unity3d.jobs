#region

using System;
using Appalachia.Core.Collections.Native;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Random = Unity.Mathematics.Random;

#endregion

namespace Appalachia.Jobs.Optimization.Utilities
{
    public struct JobRandoms : IDisposable
    {
        public const int INSTANCE_COUNT = 50000;

        public bool IsCreated => randoms.IsCreated;

        public JobRandoms(Allocator allocator)
        {
            randoms = new NativeArray<double>(INSTANCE_COUNT, allocator);

            random = new Random((uint) GLOBAL_RANDOM.random.Next(0, int.MaxValue));

            var job = new PopulateJob {random = random, randoms = randoms};

            job.Execute();
        }

        public double Get(int index)
        {
            return randoms[index % randoms.Length];
        }

        private NativeArray<double> randoms;

        private Random random;

        [BurstCompile]
        private struct PopulateJob : IJob
        {
            public Random random;
            [WriteOnly] public NativeArray<double> randoms;

            public void Execute()
            {
                for (var i = 0; i < randoms.Length; i++)
                {
                    randoms[i] = random.NextDouble();
                }
            }
        }

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
                randoms.Dispose();
            }
        }

        public bool ShouldAllocate()
        {
            return randoms.ShouldAllocate();
        }
    }
}
