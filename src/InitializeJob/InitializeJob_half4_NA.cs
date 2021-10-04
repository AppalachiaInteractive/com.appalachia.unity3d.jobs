#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_half4_NA : IJobParallelFor
    {
        [ReadOnly] public half4 input;
        [WriteOnly] public NativeArray<half4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
