/*using System;
using Unity.Collections;
using Unity.Jobs;

namespace Appalachia.Core.Optimization.Parameters
{
    public struct ParameterSet : IDisposable
    {
        public ParameterSet(int count, Allocator allocator)
        {
            parameters = new NativeArray<double>(count, allocator);
        }
        
        public NativeArray<double> parameters;
        
        public int Count => parameters.IsCreated ? parameters.Length : 0;
        
        public double this[int i] => parameters[i];

        public void Dispose(JobHandle deps)
        {
            if (parameters.IsCreated)
            {
                parameters.Dispose(deps);          
            }
            
        }
        public void Dispose()
        {
            Dispose(default);
        }
    }
}*/


