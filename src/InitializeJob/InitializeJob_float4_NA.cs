#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float4_NA : IJobParallelFor
    {
        [ReadOnly] public float4 input;
        [WriteOnly] public NativeArray<float4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
