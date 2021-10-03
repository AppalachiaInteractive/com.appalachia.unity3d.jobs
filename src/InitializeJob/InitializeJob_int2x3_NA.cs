#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int2x3_NA : IJobParallelFor
    {
        [ReadOnly] public int2x3 input;
        [WriteOnly] public NativeArray<int2x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
