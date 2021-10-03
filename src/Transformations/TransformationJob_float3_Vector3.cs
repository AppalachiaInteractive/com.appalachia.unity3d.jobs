#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Core.Jobs.Transformations
{
    [BurstCompile]
    public struct TransformationJob_float3_Vector3 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<float3> input;
        [WriteOnly] public NativeArray<Vector3> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
