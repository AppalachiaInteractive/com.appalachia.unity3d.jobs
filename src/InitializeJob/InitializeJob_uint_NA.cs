#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_uint_NA : IJobParallelFor
    {
        [ReadOnly] public uint input;
        [WriteOnly] public NativeArray<uint> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
