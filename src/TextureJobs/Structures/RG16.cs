#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RG16
    {
        public byte R, G;

        public static explicit operator int2(RG16 val)
        {
            return new int2 {x = val.R, y = val.G};
        }

        public static explicit operator RG16(int2 val)
        {
            return new RG16 {R = (byte) val.x, G = (byte) val.y};
        }

        public static RG16 operator +(RG16 lhs, RG16 rhs)
        {
            return (RG16) ((int2) lhs + (int2) rhs);
        }

        public static RG16 operator -(RG16 lhs, RG16 rhs)
        {
            return (RG16) ((int2) lhs - (int2) rhs);
        }
    }
}
