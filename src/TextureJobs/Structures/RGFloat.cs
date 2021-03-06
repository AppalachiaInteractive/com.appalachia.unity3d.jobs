#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGFloat
    {
        public float R, G;

        [DebuggerStepThrough] public static explicit operator float2(RGFloat val)
        {
            return new() {x = val.R, y = val.G};
        }

        [DebuggerStepThrough] public static explicit operator RGFloat(float2 val)
        {
            return new() {R = val.x, G = val.y};
        }

        [DebuggerStepThrough] public static RGFloat operator +(RGFloat lhs, RGFloat rhs)
        {
            return (RGFloat) new float2(lhs.R + rhs.R, lhs.G + rhs.G);
        }

        [DebuggerStepThrough] public static RGFloat operator -(RGFloat lhs, RGFloat rhs)
        {
            return (RGFloat) new float2(lhs.R - rhs.R, lhs.G - rhs.G);
        }
    }
}
