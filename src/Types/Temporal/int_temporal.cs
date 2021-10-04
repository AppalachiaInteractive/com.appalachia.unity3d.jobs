#region

using System;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int_temporal
    {
        [SerializeField] public int value;
        [SerializeField] private int _value1;
        
        public int value1 => _value1;

        public int delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => _value1 != value;

        public void Update(int newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
