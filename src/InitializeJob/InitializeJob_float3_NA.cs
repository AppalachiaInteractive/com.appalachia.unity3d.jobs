#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float3_NA : IJobParallelFor
    {
        [ReadOnly] public float3 input;
        [WriteOnly] public NativeArray<float3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
