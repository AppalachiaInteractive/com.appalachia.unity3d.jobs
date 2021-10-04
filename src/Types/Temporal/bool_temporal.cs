#region

using System;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Types.Temporal
{
    [Serializable]
    public struct bool_temporal
    {
        [SerializeField] public bool value;
        [SerializeField] private bool _value1;
        
        public bool value1 => _value1;
        
        public bool hasAnyDifference => hasDifference1;
        public bool hasDifference1 => _value1 != value;

        public void Update(bool newValue)
        {
            _value1 = value;
            value = newValue;
        }
    }
}
