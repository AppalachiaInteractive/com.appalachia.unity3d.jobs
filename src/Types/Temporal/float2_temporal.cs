#region

using System;
using Appalachia.Core.Extensions;
using Appalachia.Core.Geometry;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct float2_temporal
    {
        [SerializeField] public float2 value;
        [SerializeField] private float2 _value1;
        
        public float2 value1 => _value1;

        public float2 delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (math.abs(value - _value1) > float2c.epsilon).all();

        public void Update(float2 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
