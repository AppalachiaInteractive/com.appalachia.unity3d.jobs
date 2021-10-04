#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_half_NA : IJobParallelFor
    {
        [ReadOnly] public half input;
        [WriteOnly] public NativeArray<half> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
