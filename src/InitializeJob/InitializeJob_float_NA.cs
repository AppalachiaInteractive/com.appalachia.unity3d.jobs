#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

#endregion

namespace Appalachia.Core.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_float_NA : IJobParallelFor
    {
        [ReadOnly] public float input;
        [WriteOnly] public NativeArray<float> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
