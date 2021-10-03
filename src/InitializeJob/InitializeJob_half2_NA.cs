#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_half2_NA : IJobParallelFor
    {
        [ReadOnly] public half2 input;
        [WriteOnly] public NativeArray<half2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
