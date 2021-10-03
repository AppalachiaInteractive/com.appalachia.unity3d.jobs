#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint4_NA : IJobParallelFor
    {
        [ReadOnly] public uint4 input;
        [WriteOnly] public NativeArray<uint4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
