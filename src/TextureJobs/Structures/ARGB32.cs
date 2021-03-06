#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct ARGB32
    {
        public byte A, R, G, B;

        [DebuggerStepThrough] public static explicit operator int4(ARGB32 val)
        {
            return new()
            {
                x = val.A,
                y = val.R,
                z = val.G,
                w = val.B
            };
        }

        [DebuggerStepThrough] public static explicit operator ARGB32(int4 val)
        {
            return new()
            {
                A = (byte) val.x,
                R = (byte) val.y,
                G = (byte) val.z,
                B = (byte) val.w
            };
        }

        [DebuggerStepThrough] public static ARGB32 operator +(ARGB32 lhs, ARGB32 rhs)
        {
            return (ARGB32) ((int4) lhs + (int4) rhs);
        }

        [DebuggerStepThrough] public static ARGB32 operator -(ARGB32 lhs, ARGB32 rhs)
        {
            return (ARGB32) ((int4) lhs - (int4) rhs);
        }
    }
}
