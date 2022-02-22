using System;
using Appalachia.Utility.Constants;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float2_temporal3
    {
        [SerializeField] public float2 value;
        [SerializeField] private float2 _value1;
        [SerializeField] private float2 _value2;
        [SerializeField] private float2 _value3;

        public float2 value1 => _value1;
        public float2 value2 => _value2;
        public float2 value3 => _value3;

        public float2 delta => value - _value1;
        public float2 delta1 => _value1 - _value2;
        public float2 delta2 => _value2 - _value3;

        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3;
        public bool hasDifference1 => (math.abs(value - _value1) > float2c.epsilon).all();
        public bool hasDifference2 => (math.abs(_value1 - _value2) > float2c.epsilon).all();
        public bool hasDifference3 => (math.abs(_value2 - _value3) > float2c.epsilon).all();

        public void Update(float2 newValue)
        {
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
