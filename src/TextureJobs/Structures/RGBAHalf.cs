#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGBAHalf
    {
        public half R, G, B, A;

        [DebuggerStepThrough] public static explicit operator half4(RGBAHalf val)
        {
            return new()
            {
                x = val.R,
                y = val.G,
                z = val.B,
                w = val.A
            };
        }

        [DebuggerStepThrough] public static explicit operator RGBAHalf(half4 val)
        {
            return new()
            {
                R = val.x,
                G = val.y,
                B = val.z,
                A = val.w
            };
        }

        [DebuggerStepThrough] public static RGBAHalf operator +(RGBAHalf lhs, RGBAHalf rhs)
        {
            return (RGBAHalf) new half4(
                (half) (lhs.R + rhs.R),
                (half) (lhs.G + rhs.G),
                (half) (lhs.B + rhs.B),
                (half) (lhs.A + rhs.A)
            );
        }

        [DebuggerStepThrough] public static RGBAHalf operator -(RGBAHalf lhs, RGBAHalf rhs)
        {
            return (RGBAHalf) new half4(
                (half) (lhs.R - rhs.R),
                (half) (lhs.G - rhs.G),
                (half) (lhs.B - rhs.B),
                (half) (lhs.A - rhs.A)
            );
        }
    }
}
