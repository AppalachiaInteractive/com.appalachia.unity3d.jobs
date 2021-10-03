using System;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct bool_temporal2
    {
        [SerializeField] public bool value;
        [SerializeField] private bool _value1;
        [SerializeField] private bool _value2;
        
        public bool value1 => _value1;
        public bool value2 => _value2;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => _value1 != value;
        public bool hasDifference2 => _value2 != _value1;

        public void Update(bool newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}