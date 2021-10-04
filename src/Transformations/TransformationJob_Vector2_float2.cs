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
    public struct TransformationJob_Vector2_float2 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<Vector2> input;
        [WriteOnly] public NativeArray<float2> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i;
        }
    }
}
