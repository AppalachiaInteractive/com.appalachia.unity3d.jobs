#region

using Appalachia.Jobs.Optimization.Metadata;

#endregion

namespace Appalachia.Jobs.Optimization.Options
{
    public struct OptimizationOptions
    {
        public OptimizationOptions(RandomSearchOptions opts)
        {
            style = OptimizationStyle.RandomSearch;
            randomSearch = opts;
            gridSearch = default;
        }

        public OptimizationOptions(GridSearchOptions opts)
        {
            style = OptimizationStyle.GridSearch;
            randomSearch = default;
            gridSearch = opts;
        }

        public OptimizationStyle style;
        public RandomSearchOptions randomSearch;
        public GridSearchOptions gridSearch;
    }
}
