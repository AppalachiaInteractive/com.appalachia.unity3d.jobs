#region

using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Constants;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct double2_temporal
    {
        [SerializeField] public double2 value;
        [SerializeField] private double2 _value1;

        public double2 value1 => _value1;

        public double2 delta => value - _value1;

        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (math.abs(value - _value1) > double2c.epsilon).all();

        public void Update(double2 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
