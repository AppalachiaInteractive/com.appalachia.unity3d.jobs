#region

using System;
using Appalachia.Core.Attributes;

#endregion

namespace Appalachia.Jobs.Optimization.Utilities
{
    [CallStaticConstructorInEditor]
    public static class GLOBAL_RANDOM
    {
        private static Random _random;

        static GLOBAL_RANDOM()
        {
            _random = new Random();
        }

        public static Random random
        {
            get
            {
                if (_random == null)
                {
                    _random = new Random();
                }

                return _random;
            }
        }
    }
}
