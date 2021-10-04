#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Transformations
{
    [BurstCompile]
    public struct TransformationJob_Quaternion_quaternion : IJobParallelFor
    {
        [ReadOnly] public NativeArray<Quaternion> input;
        [WriteOnly] public NativeArray<quaternion> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
