#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool3x4_NA : IJobParallelFor
    {
        [ReadOnly] public bool3x4 input;
        [WriteOnly] public NativeArray<bool3x4> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
