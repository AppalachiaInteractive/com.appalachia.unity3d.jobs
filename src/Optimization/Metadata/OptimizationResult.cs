namespace Appalachia.Optimization.Metadata
{
    public struct OptimizationResult
    {
        public OptimizationResult(double error, int iterationIndex)
        {
            this.error = error;
            this.iterationIndex = iterationIndex;
        }

        public readonly double error;

        public readonly int iterationIndex;
    }
}
