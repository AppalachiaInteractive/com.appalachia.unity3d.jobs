#region

using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Jobs.Transformations
{
    [BurstCompile]
    public struct TransformationJob_MatrixInstance_float4x4 : IJobParallelFor
    {
        [ReadOnly] public NativeArray<MatrixInstance> input;
        [WriteOnly] public NativeArray<float4x4> output;

        public void Execute(int index)
        {
            var i = input[index];
            output[index] = i.Matrix;
        }
    }
}
