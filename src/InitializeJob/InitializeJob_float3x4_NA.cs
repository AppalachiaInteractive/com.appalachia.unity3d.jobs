#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float3x4_NA : IJobParallelFor
    {
        [ReadOnly] public float3x4 input;
        [WriteOnly] public NativeArray<float3x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
