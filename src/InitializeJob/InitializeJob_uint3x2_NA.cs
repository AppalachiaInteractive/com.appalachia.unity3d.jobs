#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint3x2_NA : IJobParallelFor
    {
        [ReadOnly] public uint3x2 input;
        [WriteOnly] public NativeArray<uint3x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
