#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float3x2_NA : IJobParallelFor
    {
        [ReadOnly] public float3x2 input;
        [WriteOnly] public NativeArray<float3x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
