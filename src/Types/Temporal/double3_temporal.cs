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
    public struct double3_temporal
    {
        [SerializeField] public double3 value;
        [SerializeField] private double3 _value1;
        
        public double3 value1 => _value1;

        public double3 delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (math.abs(value - _value1) > double3c.epsilon).all();

        public void Update(double3 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
