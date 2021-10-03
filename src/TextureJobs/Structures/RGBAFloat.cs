#region

using Unity.Mathematics;

#endregion

namespace Appalachia.Core.Globals.Jobs.TextureJobs.Structures
{
    public struct RGBAFloat
    {
        public float R, G, B, A;

        public static explicit operator float4(RGBAFloat val)
        {
            return new float4
            {
                x = val.R,
                y = val.G,
                z = val.B,
                w = val.A
            };
        }

        public static explicit operator RGBAFloat(float4 val)
        {
            return new RGBAFloat
            {
                R = val.x,
                G = val.y,
                B = val.z,
                A = val.w
            };
        }

        public static RGBAFloat operator +(RGBAFloat lhs, RGBAFloat rhs)
        {
            return (RGBAFloat) new float4(lhs.R + rhs.R, lhs.G + rhs.G, lhs.B + rhs.B, lhs.A + rhs.A);
        }

        public static RGBAFloat operator -(RGBAFloat lhs, RGBAFloat rhs)
        {
            return (RGBAFloat) new float4(lhs.R - rhs.R, lhs.G - rhs.G, lhs.B - rhs.B, lhs.A - rhs.A);
        }
    }
}
