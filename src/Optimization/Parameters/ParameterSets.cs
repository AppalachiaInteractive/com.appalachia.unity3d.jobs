/*
namespace Appalachia.Jobs.Optimization.Parameters
{
    /*public struct ParameterSets : IDisposable
    {
        public ParameterSets(int iterations, int parameters, Allocator allocator)
        {
            sets = new NativeArray<ParameterSet>(iterations, allocator);

            for (var i = 0; i < iterations; i++)
            {
                sets[i] = new ParameterSet(parameters, allocator);
            }
        }
        
        public NativeArray<ParameterSet> sets;

        public void Dispose(JobHandle deps)
        {
            
            if (sets.IsCreated)
            {
                for (var i = 0; i < sets.Length; i++)
                {
                    var set = sets[i];

                    set.Dispose(deps);
                }
            
                sets.Dispose(deps);                
            }
        }
        
        public void Dispose()
        {
            Dispose(default);
        }
    }#1#
}
*/
