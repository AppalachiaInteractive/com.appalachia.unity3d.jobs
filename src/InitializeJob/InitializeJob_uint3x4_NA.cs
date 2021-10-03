#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint3x4_NA : IJobParallelFor
    {
        [ReadOnly] public uint3x4 input;
        [WriteOnly] public NativeArray<uint3x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
