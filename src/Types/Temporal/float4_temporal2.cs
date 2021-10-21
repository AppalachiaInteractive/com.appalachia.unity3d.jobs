using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.src.Constants;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float4_temporal2
    {
        [SerializeField] public float4 value;
        [SerializeField] private float4 _value1;
        [SerializeField] private float4 _value2;

        public float4 value1 => _value1;
        public float4 value2 => _value2;

        public float4 delta => value - _value1;
        public float4 delta1 => _value1 - _value2;

        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (math.abs(value - _value1) > float4c.epsilon).all();
        public bool hasDifference2 => (math.abs(_value1 - _value2) > float4c.epsilon).all();

        public void Update(float4 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
