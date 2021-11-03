using System;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Extensions;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int3_temporal2
    {
        [SerializeField] public int3 value;
        [SerializeField] private int3 _value1;
        [SerializeField] private int3 _value2;

        public int3 value1 => _value1;
        public int3 value2 => _value2;

        public int3 delta => value - _value1;
        public int3 delta1 => _value1 - _value2;

        public bool hasAnyDifference => hasDifference1 || hasDifference2;
        public bool hasDifference1 => (_value1 != value).all();
        public bool hasDifference2 => (_value2 != _value1).all();

        public void Update(int3 newValue)
        {
            _value2 = _value1;
            _value1 = value;
            value = newValue;
        }
    }
}
