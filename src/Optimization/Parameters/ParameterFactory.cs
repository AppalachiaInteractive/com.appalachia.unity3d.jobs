#region

using System;
using Unity.Burst;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.Optimization.Parameters
{
    [BurstCompile]
    public static class ParameterFactory
    {
        /// <summary>
        ///     Return a transform from predefined selections.
        /// </summary>
        /// <returns></returns>
        public static double Transform(
            TransformType transformType,
            ParameterSamplerType samplerType,
            double min,
            double max,
            ParameterType parameterType,
            double random)
        {
            switch (transformType)
            {
                case TransformType.Linear:
                    return LinearTransform(samplerType, min, max, parameterType, random);
                case TransformType.Log10:
                    return Log10Transform(samplerType, min, max, parameterType, random);
                case TransformType.ExponentialAverage:
                    return ExponentialAverageTransform(
                        samplerType,
                        min,
                        max,
                        parameterType,
                        random
                    );
                default:
                    throw new ArgumentException("Unsupported transform type.");
            }
        }

        /// <summary>
        ///     Linear scale. For ranges with a small difference in numerical scale, like min: 64 and max: 256.
        ///     Returns the samplers value directly.
        /// </summary>
        /// <returns></returns>
        private static double LinearTransform(
            ParameterSamplerType samplerType,
            double min,
            double max,
            ParameterType parameterType,
            double random)
        {
            return Sample(samplerType, min, max, parameterType, random);
        }

        /// <summary>
        ///     Transform to Log10 scale. For ranges with a large difference in numerical scale, like min: 0.0001 and max: 1.0.
        /// </summary>
        /// <returns></returns>
        private static double Log10Transform(
            ParameterSamplerType samplerType,
            double min,
            double max,
            ParameterType parameterType,
            double random)
        {
            if ((min <= 0) || (max <= 0))
            {
                throw new ArgumentException(
                    "logarithmic scale requires min: " +
                    $"{min} and max: {max} to be larger than zero"
                );
            }

            var a = math.log10(min);
            var b = math.log10(max);

            var r = Sample(samplerType, a, b, parameterType, random);
            return math.pow(10, r);
        }

        /// <summary>
        ///     ExponentialAverage scale. For ranges close to one, like min: 0.9 and max: 0.999.
        ///     Note that the min and max values must be smaller than 1 for this transform.
        /// </summary>
        /// <returns></returns>
        private static double ExponentialAverageTransform(
            ParameterSamplerType samplerType,
            double min,
            double max,
            ParameterType parameterType,
            double random)
        {
            if ((min >= 1) || (max >= 1))
            {
                throw new ArgumentException(
                    "ExponentialAverage scale requires min: " +
                    $" {min} and max: {max} to be smaller than one"
                );
            }

            var a = math.log10(1.0 - max);
            var b = math.log10(1.0 - min);

            var r = Sample(samplerType, a, b, parameterType, random);
            return 1.0 - math.pow(10, r);
        }

        public static double Sample(
            ParameterSamplerType type,
            double min,
            double max,
            ParameterType parameterType,
            double random)
        {
            switch (type)
            {
                case ParameterSamplerType.RandomUniform:
                    return RandomUniform_Sample(min, max, parameterType, random);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        ///     Sample values random uniformly between min and max.
        /// </summary>
        /// <returns></returns>
        private static double RandomUniform_Sample(
            double min,
            double max,
            ParameterType parameterType,
            double random)
        {
            if (min >= max)
            {
                throw new ArgumentException($"min: {min} is larger than or equal to max: {max}");
            }

            switch (parameterType)
            {
                case ParameterType.Discrete:
                    return RandomUniform_SampleInteger((int) min, (int) max, random);
                case ParameterType.Continuous:
                    return RandomUniform_SampleContinous(min, max, random);
                default:
                    throw new ArgumentException("Unknown parameter type.");
            }
        }

        private static double RandomUniform_SampleContinous(double min, double max, double random)
        {
            return math.lerp(min, max, math.clamp(random, 0.0, 1.0));
        }

        private static int RandomUniform_SampleInteger(int min, int max, double random)
        {
            return (int) math.lerp(min, max + 1, math.clamp(random, 0.0, 1.0));
        }
    }
}
