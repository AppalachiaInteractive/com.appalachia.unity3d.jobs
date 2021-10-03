#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool4x2_NA : IJobParallelFor
    {
        [ReadOnly] public bool4x2 input;
        [WriteOnly] public NativeArray<bool4x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
