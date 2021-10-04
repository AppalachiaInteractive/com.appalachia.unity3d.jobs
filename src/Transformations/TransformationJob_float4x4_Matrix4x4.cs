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
    public struct TransformationJob_float4x4_Matrix4x4 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<float4x4> input;
        [WriteOnly] public NativeArray<Matrix4x4> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
