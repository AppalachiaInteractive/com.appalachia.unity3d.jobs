#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_double3x4_NA : IJobParallelFor
    {
        [ReadOnly] public double3x4 input;
        [WriteOnly] public NativeArray<double3x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
