#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGBAFloat
    {
        public float R, G, B, A;

        [DebuggerStepThrough] public static explicit operator float4(RGBAFloat val)
        {
            return new()
            {
                x = val.R,
                y = val.G,
                z = val.B,
                w = val.A
            };
        }

        [DebuggerStepThrough] public static explicit operator RGBAFloat(float4 val)
        {
            return new()
            {
                R = val.x,
                G = val.y,
                B = val.z,
                A = val.w
            };
        }

        [DebuggerStepThrough] public static RGBAFloat operator +(RGBAFloat lhs, RGBAFloat rhs)
        {
            return (RGBAFloat) new float4(
                lhs.R + rhs.R,
                lhs.G + rhs.G,
                lhs.B + rhs.B,
                lhs.A + rhs.A
            );
        }

        [DebuggerStepThrough] public static RGBAFloat operator -(RGBAFloat lhs, RGBAFloat rhs)
        {
            return (RGBAFloat) new float4(
                lhs.R - rhs.R,
                lhs.G - rhs.G,
                lhs.B - rhs.B,
                lhs.A - rhs.A
            );
        }
    }
}
