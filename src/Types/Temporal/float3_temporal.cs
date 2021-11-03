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
    public struct float3_temporal
    {
        [SerializeField] public float3 value;
        [SerializeField] private float3 _value1;

        public float3 value1 => _value1;

        public float3 delta => value - _value1;

        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (math.abs(value - _value1) > float3c.epsilon).all();

        public void Update(float3 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
