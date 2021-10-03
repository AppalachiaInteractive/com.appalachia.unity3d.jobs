#region

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

#endregion

namespace Appalachia.Core.Jobs.Transfers
{
    [BurstCompile]
    public struct TransferJob_Matrix4x4_NA_Matrix4x4_NA : IJobParallelFor
    {
        [ReadOnly] public NativeArray<Matrix4x4> input;
        [WriteOnly] public NativeArray<Matrix4x4> output;

        public void Execute(int index)
        {
            output[index] = input[index];
        }
    }
}
