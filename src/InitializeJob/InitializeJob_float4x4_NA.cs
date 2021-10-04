#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float4x4_NA : IJobParallelFor
    {
        [ReadOnly] public float4x4 input;
        [WriteOnly] public NativeArray<float4x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
