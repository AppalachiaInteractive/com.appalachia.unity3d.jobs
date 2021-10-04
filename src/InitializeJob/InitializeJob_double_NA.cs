#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_double_NA : IJobParallelFor
    {
        [ReadOnly] public double input;
        [WriteOnly] public NativeArray<double> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
