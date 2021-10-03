#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int3x4_NA : IJobParallelFor
    {
        [ReadOnly] public int3x4 input;
        [WriteOnly] public NativeArray<int3x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
