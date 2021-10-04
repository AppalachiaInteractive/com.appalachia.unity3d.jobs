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
    public struct TransformationJob_Vector4_float4 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<Vector4> input;
        [WriteOnly] public NativeArray<float4> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
