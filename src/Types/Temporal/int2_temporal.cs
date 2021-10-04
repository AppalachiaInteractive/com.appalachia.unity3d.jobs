#region

using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int2_temporal
    {
        [SerializeField] public int2 value;
        [SerializeField] private int2 _value1;
        
        public int2 value1 => _value1;

        public int2 delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (_value1 != value).all();

        public void Update(int2 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
