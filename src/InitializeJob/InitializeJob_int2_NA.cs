#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int2_NA : IJobParallelFor
    {
        [ReadOnly] public int2 input;
        [WriteOnly] public NativeArray<int2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
