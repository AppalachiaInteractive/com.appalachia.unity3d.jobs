using System;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int_temporal3
    {
        [SerializeField] public int value;
        [SerializeField] private int _value1;
        [SerializeField] private int _value2;
        [SerializeField] private int _value3;

        public int value1 => _value1;
        public int value2 => _value2;
        public int value3 => _value3;

        public int delta => value - _value1;
        public int delta1 => _value1 - _value2;
        public int delta2 => _value2 - _value3;

        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3;
        public bool hasDifference1 => _value1 != value;
        public bool hasDifference2 => _value2 != _value1;
        public bool hasDifference3 => _value3 != _value2;

        public void Update(int newValue)
        {
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
