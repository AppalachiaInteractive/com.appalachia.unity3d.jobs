#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_double2x2_NA : IJobParallelFor
    {
        [ReadOnly] public double2x2 input;
        [WriteOnly] public NativeArray<double2x2> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
