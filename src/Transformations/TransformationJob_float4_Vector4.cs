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
    public struct TransformationJob_float4_Vector4 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<float4> input;
        [WriteOnly] public NativeArray<Vector4> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
