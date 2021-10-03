using System;
using Appalachia.Core.Extensions;
using Appalachia.Core.Geometry;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct float3_temporal3
    {
        [SerializeField] public float3 value;
        [SerializeField] private float3 _value1;
        [SerializeField] private float3 _value2;
        [SerializeField] private float3 _value3;
        
        public float3 value1 => _value1;
        public float3 value2 => _value2;
        public float3 value3 => _value3;

        public float3 delta => value - _value1;
        public float3 delta1 => _value1 - _value2;
        public float3 delta2 => _value2 - _value3;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3;
        public bool hasDifference1 => (math.abs(value - _value1) > float3c.epsilon).all();
        public bool hasDifference2 => (math.abs(_value1 - _value2) > float3c.epsilon).all();
        public bool hasDifference3 => (math.abs(_value2 - _value3) > float3c.epsilon).all();

        public void Update(float3 newValue)
        {
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}