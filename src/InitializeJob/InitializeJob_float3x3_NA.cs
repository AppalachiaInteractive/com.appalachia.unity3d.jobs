#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float3x3_NA : IJobParallelFor
    {
        [ReadOnly] public float3x3 input;
        [WriteOnly] public NativeArray<float3x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
