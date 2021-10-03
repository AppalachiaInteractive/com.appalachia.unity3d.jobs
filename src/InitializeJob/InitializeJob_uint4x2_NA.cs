#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint4x2_NA : IJobParallelFor
    {
        [ReadOnly] public uint4x2 input;
        [WriteOnly] public NativeArray<uint4x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
