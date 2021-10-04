using System;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int_temporal2
    {
        [SerializeField] public int value;
        [SerializeField] private int _value1;
        [SerializeField] private int _value2;
        
        public int value1 => _value1;
        public int value2 => _value2;

        public int delta => value - _value1;
        public int delta1 => _value1 - _value2;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => _value1 != value;
        public bool hasDifference2 => _value2 != _value1;

        public void Update(int newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}