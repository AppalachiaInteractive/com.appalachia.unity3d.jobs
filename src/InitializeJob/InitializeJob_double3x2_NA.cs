#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_double3x2_NA : IJobParallelFor
    {
        [ReadOnly] public double3x2 input;
        [WriteOnly] public NativeArray<double3x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
