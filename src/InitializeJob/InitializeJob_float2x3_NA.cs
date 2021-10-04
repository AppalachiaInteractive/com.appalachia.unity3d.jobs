#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float2x3_NA : IJobParallelFor
    {
        [ReadOnly] public float2x3 input;
        [WriteOnly] public NativeArray<float2x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
