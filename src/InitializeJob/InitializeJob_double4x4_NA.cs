#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_double4x4_NA : IJobParallelFor
    {
        [ReadOnly] public double4x4 input;
        [WriteOnly] public NativeArray<double4x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
