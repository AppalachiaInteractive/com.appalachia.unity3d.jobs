#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint2x2_NA : IJobParallelFor
    {
        [ReadOnly] public uint2x2 input;
        [WriteOnly] public NativeArray<uint2x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
