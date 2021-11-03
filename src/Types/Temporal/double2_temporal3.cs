using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Constants;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct double2_temporal3
    {
        [SerializeField] public double2 value;
        [SerializeField] private double2 _value1;
        [SerializeField] private double2 _value2;
        [SerializeField] private double2 _value3;

        public double2 value1 => _value1;
        public double2 value2 => _value2;
        public double2 value3 => _value3;

        public double2 delta => value - _value1;
        public double2 delta1 => _value1 - _value2;
        public double2 delta2 => _value2 - _value3;

        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3;
        public bool hasDifference1 => (math.abs(value - _value1) > double2c.epsilon).all();
        public bool hasDifference2 => (math.abs(value1 - _value2) > double2c.epsilon).all();
        public bool hasDifference3 => (math.abs(value2 - _value3) > double2c.epsilon).all();

        public void Update(double2 newValue)
        {
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
