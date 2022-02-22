using System;
using Appalachia.Utility.Constants;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct double4_temporal4
    {
        [SerializeField] public double4 value;
        [SerializeField] private double4 _value1;
        [SerializeField] private double4 _value2;
        [SerializeField] private double4 _value3;
        [SerializeField] private double4 _value4;

        public double4 value1 => _value1;
        public double4 value2 => _value2;
        public double4 value3 => _value3;
        public double4 value4 => _value4;

        public double4 delta => value - _value1;
        public double4 delta1 => _value1 - _value2;
        public double4 delta2 => _value2 - _value3;
        public double4 delta3 => _value3 - _value4;

        public bool hasAnyDifference =>
            hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;

        public bool hasDifference1 => (math.abs(value - _value1) > double4c.epsilon).all();
        public bool hasDifference2 => (math.abs(value1 - _value2) > double4c.epsilon).all();
        public bool hasDifference3 => (math.abs(value2 - _value3) > double4c.epsilon).all();
        public bool hasDifference4 => (math.abs(value3 - _value4) > double4c.epsilon).all();

        public void Update(double4 newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
