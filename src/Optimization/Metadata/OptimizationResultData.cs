#region

using System;
using Appalachia.Core.Collections.Native;
using Unity.Collections;

#endregion

namespace Appalachia.Jobs.Optimization.Metadata
{
    public struct OptimizationResultData : IDisposable
    {
        public OptimizationResultData(Allocator allocator)
        {
            bestResultArray = new NativeArray<OptimizationResult>(1, allocator);
            allResults = default;
        }

        public NativeList<OptimizationResult> allResults;

        public NativeArray<OptimizationResult> bestResultArray;

        public OptimizationResult Result
        {
            get => bestResultArray[0];
            set => bestResultArray[0] = value;
        }

        /*public void Dispose(JobHandle deps)
        {
            if (allResults.IsCreated)
            {
                allResults.Dispose(deps);
            }
            
            if (bestResultArray.IsCreated)
            {
                bestResultArray.Dispose(deps);          
            }
            
        }*/
        public void Dispose()
        {
            allResults.SafeDispose();
            bestResultArray.SafeDispose();
        }
    }
}
