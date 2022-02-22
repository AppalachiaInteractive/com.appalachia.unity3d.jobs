using System;
using Appalachia.Utility.Constants;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct double3_temporal3
    {
        [SerializeField] public double3 value;
        [SerializeField] private double3 _value1;
        [SerializeField] private double3 _value2;
        [SerializeField] private double3 _value3;

        public double3 value1 => _value1;
        public double3 value2 => _value2;
        public double3 value3 => _value3;

        public double3 delta => value - _value1;
        public double3 delta1 => _value1 - _value2;
        public double3 delta2 => _value2 - _value3;

        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3;
        public bool hasDifference1 => (math.abs(value - _value1) > double3c.epsilon).all();
        public bool hasDifference2 => (math.abs(value1 - _value2) > double3c.epsilon).all();
        public bool hasDifference3 => (math.abs(value2 - _value3) > double3c.epsilon).all();

        public void Update(double3 newValue)
        {
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
