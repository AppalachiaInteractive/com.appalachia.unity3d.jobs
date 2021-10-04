#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool3x2_NA : IJobParallelFor
    {
        [ReadOnly] public bool3x2 input;
        [WriteOnly] public NativeArray<bool3x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
