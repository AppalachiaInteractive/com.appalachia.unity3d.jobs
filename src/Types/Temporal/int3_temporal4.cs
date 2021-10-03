using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct int3_temporal4
    {
        [SerializeField] public int3 value;
        [SerializeField] private int3 _value1;
        [SerializeField] private int3 _value2;
        [SerializeField] private int3 _value3;
        [SerializeField] private int3 _value4;
        
        public int3 value1 => _value1;
        public int3 value2 => _value2;
        public int3 value3 => _value3;
        public int3 value4 => _value4;

        public int3 delta => value - _value1;
        public int3 delta1 => _value1 - _value2;
        public int3 delta2 => _value2 - _value3;
        public int3 delta3 => _value3 - _value4;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;
        public bool hasDifference1 => (_value1 != value).all();
        public bool hasDifference2 => (_value2 != _value1).all();
        public bool hasDifference3 => (_value3 != _value2).all();
        public bool hasDifference4 => (_value4 != _value3).all();

        public void Update(int3 newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}