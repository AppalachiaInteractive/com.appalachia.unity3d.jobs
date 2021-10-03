namespace Appalachia.Optimization.Parameters
{
    public enum TransformType
    {
        /// <summary>
        ///     Linear scale. For ranges with a small difference in numerical scale, like min: 64 and max: 256.
        /// </summary>
        Linear = 0,

        /// <summary>
        ///     Logarithmic scale. For ranges with a large difference in numerical scale, like min: 0.0001 and max: 1.0.
        /// </summary>
        Log10 = 10,

        /// <summary>
        ///     ExponentialAverage scale. For ranges close to one, like min: 0.9 and max: 0.999.
        /// </summary>
        ExponentialAverage = 20
    }
}
