#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_half3_NA : IJobParallelFor
    {
        [ReadOnly] public half3 input;
        [WriteOnly] public NativeArray<half3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
