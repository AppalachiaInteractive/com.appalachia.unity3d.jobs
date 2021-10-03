using System;
using Appalachia.Core.Extensions;
using Appalachia.Core.Geometry;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct double2_temporal2
    {
        [SerializeField] public double2 value;
        [SerializeField] private double2 _value1;
        [SerializeField] private double2 _value2;
        
        public double2 value1 => _value1;
        public double2 value2 => _value2;

        public double2 delta => value - _value1;
        public double2 delta1 => _value1 - _value2;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (math.abs(value - _value1) > double2c.epsilon).all();
        public bool hasDifference2 => (math.abs(value1 - _value2) > double2c.epsilon).all();

        public void Update(double2 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}