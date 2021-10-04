#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int2x4_NA : IJobParallelFor
    {
        [ReadOnly] public int2x4 input;
        [WriteOnly] public NativeArray<int2x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
