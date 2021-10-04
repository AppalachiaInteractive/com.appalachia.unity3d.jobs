using System;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct bool_temporal4
    {
        [SerializeField] public bool value;
        [SerializeField] private bool _value1;
        [SerializeField] private bool _value2;
        [SerializeField] private bool _value3;
        [SerializeField] private bool _value4;

        public bool value1 => _value1;
        public bool value2 => _value2;
        public bool value3 => _value3;
        public bool value4 => _value4;

        public bool hasAnyDifference =>
            hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;

        public bool hasDifference1 => _value1 != value;
        public bool hasDifference2 => _value2 != _value1;
        public bool hasDifference3 => _value3 != _value2;
        public bool hasDifference4 => _value4 != _value3;

        public void Update(bool newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
