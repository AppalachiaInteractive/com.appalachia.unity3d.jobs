#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGBA32
    {
        public byte R, G, B, A;

        [DebuggerStepThrough] public static explicit operator int4(RGBA32 val)
        {
            return new()
            {
                x = val.R,
                y = val.G,
                z = val.B,
                w = val.A
            };
        }

        [DebuggerStepThrough] public static explicit operator RGBA32(int4 val)
        {
            return new()
            {
                R = (byte) val.x,
                G = (byte) val.y,
                B = (byte) val.z,
                A = (byte) val.w
            };
        }

        [DebuggerStepThrough] public static RGBA32 operator +(RGBA32 lhs, RGBA32 rhs)
        {
            return (RGBA32) ((int4) lhs + (int4) rhs);
        }

        [DebuggerStepThrough] public static RGBA32 operator -(RGBA32 lhs, RGBA32 rhs)
        {
            return (RGBA32) ((int4) lhs - (int4) rhs);
        }
    }
}
