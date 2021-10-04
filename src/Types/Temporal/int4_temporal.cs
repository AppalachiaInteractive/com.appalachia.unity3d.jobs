#region

using System;
using Appalachia.Core.Extensions;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct int4_temporal
    {
        [SerializeField] public int4 value;
        [SerializeField] private int4 _value1;
        
        public int4 value1 => _value1;

        public int4 delta => value - _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => (_value1 != value).all();

        public void Update(int4 newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
