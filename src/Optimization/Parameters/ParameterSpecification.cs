#region

using System;

#endregion

namespace Appalachia.Jobs.Optimization.Parameters
{
    public struct ParameterSpecification //: IDisposable
    {
        public readonly ParameterSpecificationType specificationType;
        public readonly ParameterSamplerType samplerType;
        public readonly TransformType transformType;
        public readonly ParameterType parameterType;
        public readonly double minimum;

        public readonly double maximum;

        //public NativeArray<double> parameters;
        public readonly int minIndex;
        public readonly int maxIndex;

        /*public ParameterSpecification(TransformType transformType, Allocator allocator, NativeArray<double> parameters)
        {
            this.specificationType = ParameterSpecificationType.GridParameter;
            this.samplerType = ParameterSamplerType.RandomUniform;
            this.transformType = transformType;
            this.parameterType = ParameterType.Discrete;

            this.parameters = parameters;
            this.minIndex = 0;
            this.maxIndex = parameters.Length - 1;

            this.minimum = double.MaxValue;
            this.maximum = double.MinValue;

            for (var i = 0; i < parameters.Length; i++)
            {
                this.minimum = math.min(this.minimum, parameters[i]);
                this.maximum = math.max(this.maximum, parameters[i]);
            }
        }*/

        public ParameterSpecification(TransformType transformType, ParameterType parameterType, double minimum, double maximum)
        {
            specificationType = ParameterSpecificationType.MinMaxParameter;
            samplerType = ParameterSamplerType.RandomUniform;
            this.transformType = transformType;
            this.parameterType = parameterType;

            this.minimum = minimum;
            this.maximum = maximum;
            minIndex = 0;
            maxIndex = 0;

            //this.parameters = default;
        }

        public double SampleValue(double random)
        {
            switch (specificationType)
            {
                /*case ParameterSpecificationType.GridParameter:

                    var index = (int) ParameterFactory.Sample(samplerType, minIndex, maxIndex, parameterType, random);

                    return parameters[index];*/

                case ParameterSpecificationType.MinMaxParameter:

                    return ParameterFactory.Transform(transformType, samplerType, minimum, maximum, parameterType, random);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /*public NativeArray<double> GetAllValues()
        {
            switch (specificationType)
            {
                case ParameterSpecificationType.GridParameter:
                    return parameters;
                case ParameterSpecificationType.MinMaxParameter:
                    throw new NotImplementedException(
                        $"Get all values is not available for {nameof(ParameterSpecificationType.MinMaxParameter)}"
                    );
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }*/

        /*public void Dispose(JobHandle deps)
        {
            /*if (parameters.IsCreated)
            {
                parameters.Dispose(deps);          
            }#1#
            
        }
        public void Dispose()
        {
            Dispose(default);
        }*/
    }
}
