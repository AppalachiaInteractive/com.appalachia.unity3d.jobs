using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int4_temporal2
    {
        [SerializeField] public int4 value;
        [SerializeField] private int4 _value1;
        [SerializeField] private int4 _value2;
        
        public int4 value1 => _value1;
        public int4 value2 => _value2;

        public int4 delta => value - _value1;
        public int4 delta1 => _value1 - _value2;
        
        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (_value1 != value).all();
        public bool hasDifference2 => (_value2 != _value1).all();

        public void Update(int4 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}