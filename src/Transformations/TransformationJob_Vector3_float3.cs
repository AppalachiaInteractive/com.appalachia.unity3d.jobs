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
    public struct TransformationJob_Vector3_float3 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<Vector3> input;
        [WriteOnly] public NativeArray<float3> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
