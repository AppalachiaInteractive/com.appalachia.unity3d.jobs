#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool_NA : IJobParallelFor
    {
        [ReadOnly] public bool input;
        [WriteOnly] public NativeArray<bool> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
