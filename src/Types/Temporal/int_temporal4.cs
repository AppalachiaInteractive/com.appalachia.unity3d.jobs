using System;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct int_temporal4
    {
        [SerializeField] public int value;
        [SerializeField] private int _value1;
        [SerializeField] private int _value2;
        [SerializeField] private int _value3;
        [SerializeField] private int _value4;
        
        public int value1 => _value1;
        public int value2 => _value2;
        public int value3 => _value3;
        public int value4 => _value4;

        public int delta => value - _value1;
        public int delta1 => _value1 - _value2;
        public int delta2 => _value2 - _value3;
        public int delta3 => _value3 - _value4;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;
        public bool hasDifference1 => _value1 != value;
        public bool hasDifference2 => _value2 != _value1;
        public bool hasDifference3 => _value3 != _value2;
        public bool hasDifference4 => _value4 != _value3;

        public void Update(int newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}