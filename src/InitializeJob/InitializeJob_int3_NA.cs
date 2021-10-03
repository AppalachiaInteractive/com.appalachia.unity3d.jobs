#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int3_NA : IJobParallelFor
    {
        [ReadOnly] public int3 input;
        [WriteOnly] public NativeArray<int3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
