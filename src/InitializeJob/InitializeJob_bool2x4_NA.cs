#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool2x4_NA : IJobParallelFor
    {
        [ReadOnly] public bool2x4 input;
        [WriteOnly] public NativeArray<bool2x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
