#region

using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int3_temporal
    {
        [SerializeField] public int3 value;
        [SerializeField] private int3 _value1;
        
        public int3 value1 => _value1;

        public int3 delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (_value1 != value).all();

        public void Update(int3 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
