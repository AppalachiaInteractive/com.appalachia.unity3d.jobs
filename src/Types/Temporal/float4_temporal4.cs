using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float4_temporal4
    {
        [SerializeField] public float4 value;
        [SerializeField] private float4 _value1;
        [SerializeField] private float4 _value2;
        [SerializeField] private float4 _value3;
        [SerializeField] private float4 _value4;
        
        public float4 value1 => _value1;
        public float4 value2 => _value2;
        public float4 value3 => _value3;
        public float4 value4 => _value4;

        public float4 delta => value - _value1;
        public float4 delta1 => _value1 - _value2;
        public float4 delta2 => _value2 - _value3;
        public float4 delta3 => _value3 - _value4;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;
        public bool hasDifference1 => (math.abs(value - _value1) > float4c.epsilon).all();
        public bool hasDifference2 => (math.abs(_value1 - _value2) > float4c.epsilon).all();
        public bool hasDifference3 => (math.abs(_value2 - _value3) > float4c.epsilon).all();
        public bool hasDifference4 => (math.abs(_value3 - _value4) > float4c.epsilon).all();

        public void Update(float4 newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}