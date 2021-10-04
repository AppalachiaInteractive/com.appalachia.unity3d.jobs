#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGHalf
    {
        public half R, G;

        public static explicit operator half2(RGHalf val)
        {
            return new half2 {x = val.R, y = val.G};
        }

        public static explicit operator RGHalf(half2 val)
        {
            return new RGHalf {R = val.x, G = val.y};
        }

        public static RGHalf operator +(RGHalf lhs, RGHalf rhs)
        {
            return (RGHalf) new half2((half) (lhs.R + rhs.R), (half) (lhs.G + rhs.G));
        }

        public static RGHalf operator -(RGHalf lhs, RGHalf rhs)
        {
            return (RGHalf) new half2((half) (lhs.R - rhs.R), (half) (lhs.G - rhs.G));
        }
    }
}
