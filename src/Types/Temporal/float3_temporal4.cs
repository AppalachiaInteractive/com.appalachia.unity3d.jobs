using System;
using Appalachia.Utility.Constants;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float3_temporal4
    {
        [SerializeField] public float3 value;
        [SerializeField] private float3 _value1;
        [SerializeField] private float3 _value2;
        [SerializeField] private float3 _value3;
        [SerializeField] private float3 _value4;

        public float3 value1 => _value1;
        public float3 value2 => _value2;
        public float3 value3 => _value3;
        public float3 value4 => _value4;

        public float3 delta => value - _value1;
        public float3 delta1 => _value1 - _value2;
        public float3 delta2 => _value2 - _value3;
        public float3 delta3 => _value3 - _value4;

        public bool hasAnyDifference =>
            hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;

        public bool hasDifference1 => (math.abs(value - _value1) > float3c.epsilon).all();
        public bool hasDifference2 => (math.abs(_value1 - _value2) > float3c.epsilon).all();
        public bool hasDifference3 => (math.abs(_value2 - _value3) > float3c.epsilon).all();
        public bool hasDifference4 => (math.abs(_value3 - _value4) > float3c.epsilon).all();

        public void Update(float3 newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
