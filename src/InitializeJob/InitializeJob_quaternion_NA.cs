#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.InitializeJob
{
    [BurstCompile]
    public struct InitializeJob_quaternion_NA : IJobParallelFor
    {
        [ReadOnly] public quaternion input;
        [WriteOnly] public NativeArray<quaternion> output;

        public void Execute(int index)
        {
            output[index] = input;
        }
    }
}
