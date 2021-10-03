using System;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct double_temporal2
    {
        [SerializeField] public double value;
        [SerializeField] private double _value1;
        [SerializeField] private double _value2;
        
        public double value1 => _value1;
        public double value2 => _value2;

        public double delta => value - _value1;
        public double delta1 => _value1 - _value2;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => math.abs(value - _value1) > double.Epsilon;
        public bool hasDifference2 => math.abs(value1 - _value2) > double.Epsilon;

        public void Update(double newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}