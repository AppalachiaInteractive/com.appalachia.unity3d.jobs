#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint3x3_NA : IJobParallelFor
    {
        [ReadOnly] public uint3x3 input;
        [WriteOnly] public NativeArray<uint3x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
