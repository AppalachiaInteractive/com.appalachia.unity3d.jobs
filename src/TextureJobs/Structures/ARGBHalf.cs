#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct ARGBHalf
    {
        public half R, G, B, A;

        public static explicit operator half4(ARGBHalf val)
        {
            return new()
            {
                x = val.A,
                y = val.R,
                z = val.G,
                w = val.B
            };
        }

        public static explicit operator ARGBHalf(half4 val)
        {
            return new()
            {
                A = val.x,
                R = val.y,
                G = val.z,
                B = val.w
            };
        }

        public static ARGBHalf operator +(ARGBHalf lhs, ARGBHalf rhs)
        {
            return (ARGBHalf) new half4(
                (half) (lhs.A + rhs.A),
                (half) (lhs.R + rhs.R),
                (half) (lhs.G + rhs.G),
                (half) (lhs.B + rhs.B)
            );
        }

        public static ARGBHalf operator -(ARGBHalf lhs, ARGBHalf rhs)
        {
            return (ARGBHalf) new half4(
                (half) (lhs.A - rhs.A),
                (half) (lhs.R - rhs.R),
                (half) (lhs.G - rhs.G),
                (half) (lhs.B - rhs.B)
            );
        }
    }
}
