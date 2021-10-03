using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Core.Jobs.Types.temporal
{
    [Serializable]
    public struct int2_temporal2
    {
        [SerializeField] public int2 value;
        [SerializeField] private int2 _value1;
        [SerializeField] private int2 _value2;
        
        public int2 value1 => _value1;
        public int2 value2 => _value2;

        public int2 delta => value - _value1;
        public int2 delta1 => _value1 - _value2;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (_value1 != value).all();
        public bool hasDifference2 => (_value2 != _value1).all();

        public void Update(int2 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}