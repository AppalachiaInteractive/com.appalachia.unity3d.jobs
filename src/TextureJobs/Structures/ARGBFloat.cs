#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct ARGBFloat
    {
        public float R, G, B, A;

        [DebuggerStepThrough] public static explicit operator float4(ARGBFloat val)
        {
            return new()
            {
                x = val.A,
                y = val.R,
                z = val.G,
                w = val.B
            };
        }

        [DebuggerStepThrough] public static explicit operator ARGBFloat(float4 val)
        {
            return new()
            {
                A = val.x,
                R = val.y,
                G = val.z,
                B = val.w
            };
        }

        [DebuggerStepThrough] public static ARGBFloat operator +(ARGBFloat lhs, ARGBFloat rhs)
        {
            return (ARGBFloat) new float4(
                lhs.A + rhs.A,
                lhs.R + rhs.R,
                lhs.G + rhs.G,
                lhs.B + rhs.B
            );
        }

        [DebuggerStepThrough] public static ARGBFloat operator -(ARGBFloat lhs, ARGBFloat rhs)
        {
            return (ARGBFloat) new float4(
                lhs.A - rhs.A,
                lhs.R - rhs.R,
                lhs.G - rhs.G,
                lhs.B - rhs.B
            );
        }
    }
}
