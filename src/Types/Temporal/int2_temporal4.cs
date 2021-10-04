using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int2_temporal4
    {
        [SerializeField] public int2 value;
        [SerializeField] private int2 _value1;
        [SerializeField] private int2 _value2;
        [SerializeField] private int2 _value3;
        [SerializeField] private int2 _value4;
        
        public int2 value1 => _value1;
        public int2 value2 => _value2;
        public int2 value3 => _value3;
        public int2 value4 => _value4;

        public int2 delta => value - _value1;
        public int2 delta1 => _value1 - _value2;
        public int2 delta2 => _value2 - _value3;
        public int2 delta3 => _value3 - _value4;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2 || hasDifference3 || hasDifference4;
        public bool hasDifference1 => (_value1 != value).all();
        public bool hasDifference2 => (_value2 != _value1).all();
        public bool hasDifference3 => (_value3 != _value2).all();
        public bool hasDifference4 => (_value4 != _value3).all();

        public void Update(int2 newValue)
        {
            _value4 = _value3;
            _value3 = _value2;
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}