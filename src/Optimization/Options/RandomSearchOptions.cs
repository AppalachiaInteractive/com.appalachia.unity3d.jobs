namespace Appalachia.Optimization.Options
{
    public struct RandomSearchOptions
    {
        public RandomSearchOptions(int iterations = 150, int innerLoop = 128)
        {
            this.iterations = iterations;
            this.innerLoop = innerLoop;
        }

        public int iterations;
        public int innerLoop;
    }
}
