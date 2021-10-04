#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint4x3_NA : IJobParallelFor
    {
        [ReadOnly] public uint4x3 input;
        [WriteOnly] public NativeArray<uint4x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
