#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint3_NA : IJobParallelFor
    {
        [ReadOnly] public uint3 input;
        [WriteOnly] public NativeArray<uint3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
