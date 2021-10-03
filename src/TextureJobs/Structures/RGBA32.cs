#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Globals.Jobs.TextureJobs.Structures
{
    public struct RGBA32
    {
        public byte R, G, B, A;

        public static explicit operator int4(RGBA32 val)
        {
            return new int4
            {
                x = val.R,
                y = val.G,
                z = val.B,
                w = val.A
            };
        }

        public static explicit operator RGBA32(int4 val)
        {
            return new RGBA32
            {
                R = (byte) val.x,
                G = (byte) val.y,
                B = (byte) val.z,
                A = (byte) val.w
            };
        }

        public static RGBA32 operator +(RGBA32 lhs, RGBA32 rhs)
        {
            return (RGBA32) ((int4) lhs + (int4) rhs);
        }

        public static RGBA32 operator -(RGBA32 lhs, RGBA32 rhs)
        {
            return (RGBA32) ((int4) lhs - (int4) rhs);
        }
    }
}
