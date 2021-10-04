#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint2_NA : IJobParallelFor
    {
        [ReadOnly] public uint2 input;
        [WriteOnly] public NativeArray<uint2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
