#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGHalf
    {
        public half R, G;

        [DebuggerStepThrough] public static explicit operator half2(RGHalf val)
        {
            return new() {x = val.R, y = val.G};
        }

        [DebuggerStepThrough] public static explicit operator RGHalf(half2 val)
        {
            return new() {R = val.x, G = val.y};
        }

        [DebuggerStepThrough] public static RGHalf operator +(RGHalf lhs, RGHalf rhs)
        {
            return (RGHalf) new half2((half) (lhs.R + rhs.R), (half) (lhs.G + rhs.G));
        }

        [DebuggerStepThrough] public static RGHalf operator -(RGHalf lhs, RGHalf rhs)
        {
            return (RGHalf) new half2((half) (lhs.R - rhs.R), (half) (lhs.G - rhs.G));
        }
    }
}
