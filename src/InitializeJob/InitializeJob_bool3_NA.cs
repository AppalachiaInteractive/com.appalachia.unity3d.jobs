#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_bool3_NA : IJobParallelFor
    {
        [ReadOnly] public bool3 input;
        [WriteOnly] public NativeArray<bool3> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
