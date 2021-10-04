#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGB48
    {
        public half R, G, B;

        public static explicit operator half3(RGB48 val)
        {
            return new() {x = val.R, y = val.G, z = val.B};
        }

        public static explicit operator RGB48(half3 val)
        {
            return new() {R = val.x, G = val.y, B = val.z};
        }

        public static RGB48 operator +(RGB48 lhs, RGB48 rhs)
        {
            return (RGB48) new half3(
                (half) (lhs.R + rhs.R),
                (half) (lhs.G + rhs.G),
                (half) (lhs.B + rhs.B)
            );
        }

        public static RGB48 operator -(RGB48 lhs, RGB48 rhs)
        {
            return (RGB48) new half3(
                (half) (lhs.R - rhs.R),
                (half) (lhs.G - rhs.G),
                (half) (lhs.B - rhs.B)
            );
        }
    }
}
