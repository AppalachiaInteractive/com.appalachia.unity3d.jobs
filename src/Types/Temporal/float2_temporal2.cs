using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float2_temporal2
    {
        [SerializeField] public float2 value;
        [SerializeField] private float2 _value1;
        [SerializeField] private float2 _value2;

        public float2 value1 => _value1;
        public float2 value2 => _value2;

        public float2 delta => value - _value1;
        public float2 delta1 => _value1 - _value2;

        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (math.abs(value - _value1) > float2c.epsilon).all();
        public bool hasDifference2 => (math.abs(_value1 - _value2) > float2c.epsilon).all();

        public void Update(float2 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
