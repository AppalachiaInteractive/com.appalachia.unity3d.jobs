#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Globals.Jobs.TextureJobs.Structures
{
    public struct RGB96
    {
        public float R, G, B;

        public static explicit operator float3(RGB96 val)
        {
            return new float3 {x = val.R, y = val.G, z = val.B};
        }

        public static explicit operator RGB96(float3 val)
        {
            return new RGB96 {R = val.x, G = val.y, B = val.z};
        }

        public static RGB96 operator +(RGB96 lhs, RGB96 rhs)
        {
            return (RGB96) new float3(lhs.R + rhs.R, lhs.G + rhs.G, lhs.B + rhs.B);
        }

        public static RGB96 operator -(RGB96 lhs, RGB96 rhs)
        {
            return (RGB96) new float3(lhs.R - rhs.R, lhs.G - rhs.G, lhs.B - rhs.B);
        }
    }
}
