#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int4x3_NA : IJobParallelFor
    {
        [ReadOnly] public int4x3 input;
        [WriteOnly] public NativeArray<int4x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
