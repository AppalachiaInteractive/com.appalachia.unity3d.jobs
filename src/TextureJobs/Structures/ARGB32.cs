#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Globals.Jobs.TextureJobs.Structures
{
    public struct ARGB32
    {
        public byte A, R, G, B;

        public static explicit operator int4(ARGB32 val)
        {
            return new int4
            {
                x = val.A,
                y = val.R,
                z = val.G,
                w = val.B
            };
        }

        public static explicit operator ARGB32(int4 val)
        {
            return new ARGB32
            {
                A = (byte) val.x,
                R = (byte) val.y,
                G = (byte) val.z,
                B = (byte) val.w
            };
        }

        public static ARGB32 operator +(ARGB32 lhs, ARGB32 rhs)
        {
            return (ARGB32) ((int4) lhs + (int4) rhs);
        }

        public static ARGB32 operator -(ARGB32 lhs, ARGB32 rhs)
        {
            return (ARGB32) ((int4) lhs - (int4) rhs);
        }
    }
}
