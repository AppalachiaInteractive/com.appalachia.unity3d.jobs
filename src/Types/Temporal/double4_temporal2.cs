using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct double4_temporal2
    {
        [SerializeField] public double4 value;
        [SerializeField] private double4 _value1;
        [SerializeField] private double4 _value2;

        public double4 value1 => _value1;
        public double4 value2 => _value2;

        public double4 delta => value - _value1;
        public double4 delta1 => _value1 - _value2;

        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (math.abs(value - _value1) > double4c.epsilon).all();
        public bool hasDifference2 => (math.abs(value1 - _value2) > double4c.epsilon).all();

        public void Update(double4 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
