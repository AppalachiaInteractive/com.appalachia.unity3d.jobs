#region

using System;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float_temporal
    {
        [SerializeField] public float value;
        [SerializeField] private float _value1;
        
        public float value1 => _value1;

        public float delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => math.abs(value - _value1) > float.Epsilon;

        public void Update(float newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
