#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGB24
    {
        public byte R, G, B;

        public static explicit operator int3(RGB24 val)
        {
            return new() {x = val.R, y = val.G, z = val.B};
        }

        public static explicit operator RGB24(int3 val)
        {
            return new() {R = (byte) val.x, G = (byte) val.y, B = (byte) val.z};
        }

        public static RGB24 operator +(RGB24 lhs, RGB24 rhs)
        {
            return (RGB24) ((int3) lhs + (int3) rhs);
        }

        public static RGB24 operator -(RGB24 lhs, RGB24 rhs)
        {
            return (RGB24) ((int3) lhs - (int3) rhs);
        }
    }
}
