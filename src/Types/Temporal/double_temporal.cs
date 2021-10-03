#region

using System;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct double_temporal
    {
        [SerializeField] public double value;
        [SerializeField] private double _value1;
        
        public double value1 => _value1;

        public double delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => math.abs(value - _value1) > double.Epsilon;

        public void Update(double newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
