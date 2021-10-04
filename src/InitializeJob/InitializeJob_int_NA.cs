#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_int_NA : IJobParallelFor
    {
        [ReadOnly] public int input;
        [WriteOnly] public NativeArray<int> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
