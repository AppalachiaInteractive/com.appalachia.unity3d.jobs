#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool3x3_NA : IJobParallelFor
    {
        [ReadOnly] public bool3x3 input;
        [WriteOnly] public NativeArray<bool3x3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
