namespace Appalachia.Optimization.Options
{
    public struct GridSearchOptions
    {
        public GridSearchOptions(int iterations = 150, int innerLoop = 128)
        {
            this.iterations = iterations;
            this.innerLoop = innerLoop;
        }

        public readonly int iterations;
        public readonly int innerLoop;
    }
}
