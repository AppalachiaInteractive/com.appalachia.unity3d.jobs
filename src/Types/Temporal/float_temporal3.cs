using System;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float_temporal3
    {
        [SerializeField] public float value;
        [SerializeField] private float _value1;
        [SerializeField] private float _value2;
        [SerializeField] private float _value3;
        
        public float value1 => _value1;
        public float value2 => _value2;
        public float value3 => _value3;

        public float delta => value - _value1;
        public float delta1 => _value1 - _value2;
        public float delta2 => _value2 - _value3;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3;
        public bool hasDifference1 => math.abs(value - _value1) > float.Epsilon;
        public bool hasDifference2 => math.abs(value1 - _value2) > float.Epsilon;
        public bool hasDifference3 => math.abs(value2 - _value3) > float.Epsilon;

        public void Update(float newValue)
        {
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}