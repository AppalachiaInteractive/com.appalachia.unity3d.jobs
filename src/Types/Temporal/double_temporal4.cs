using System;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct double_temporal4
    {
        [SerializeField] public double value;
        [SerializeField] private double _value1;
        [SerializeField] private double _value2;
        [SerializeField] private double _value3;
        [SerializeField] private double _value4;
        
        public double value1 => _value1;
        public double value2 => _value2;
        public double value3 => _value3;
        public double value4 => _value4;

        public double delta => value - _value1;
        public double delta1 => _value1 - _value2;
        public double delta2 => _value2 - _value3;
        public double delta3 => _value3 - _value4;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;
        public bool hasDifference1 => math.abs(value - _value1) > double.Epsilon;
        public bool hasDifference2 => math.abs(value1 - _value2) > double.Epsilon;
        public bool hasDifference3 => math.abs(value2 - _value3) > double.Epsilon;
        public bool hasDifference4 => math.abs(value3 - _value4) > double.Epsilon;

        public void Update(double newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}