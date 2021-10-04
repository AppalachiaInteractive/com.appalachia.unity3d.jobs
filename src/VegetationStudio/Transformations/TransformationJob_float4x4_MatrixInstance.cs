#region

using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.VegetationStudio.Transformations
{
    [BurstCompile]
    public struct TransformationJob_float4x4_MatrixInstance : IJobParallelFor
    {
        [ReadOnly] public NativeArray<float4x4> input;
        public NativeArray<MatrixInstance> output;

        public void Execute(int index)
        {
            var i = input[index];
            var o = output[index];
            o.Matrix = i;
            output[index] = o;
        }
    }
}
