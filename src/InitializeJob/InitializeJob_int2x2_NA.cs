#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int2x2_NA : IJobParallelFor
    {
        [ReadOnly] public int2x2 input;
        [WriteOnly] public NativeArray<int2x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
