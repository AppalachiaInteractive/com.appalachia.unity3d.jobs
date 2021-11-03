#region

using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Constants;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct float4_temporal
    {
        [SerializeField] public float4 value;
        [SerializeField] private float4 _value1;

        public float4 value1 => _value1;

        public float4 delta => value - _value1;

        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (math.abs(value - _value1) > float4c.epsilon).all();

        public void Update(float4 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
