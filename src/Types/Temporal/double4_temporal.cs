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
    public struct double4_temporal
    {
        [SerializeField] public double4 value;
        [SerializeField] private double4 _value1;

        public double4 value1 => _value1;

        public double4 delta => value - _value1;

        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (math.abs(value - _value1) > double4c.epsilon).all();

        public void Update(double4 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
