#region

using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RG16
    {
        public byte R, G;

        [DebuggerStepThrough] public static explicit operator int2(RG16 val)
        {
            return new() {x = val.R, y = val.G};
        }

        [DebuggerStepThrough] public static explicit operator RG16(int2 val)
        {
            return new() {R = (byte) val.x, G = (byte) val.y};
        }

        [DebuggerStepThrough] public static RG16 operator +(RG16 lhs, RG16 rhs)
        {
            return (RG16) ((int2) lhs + (int2) rhs);
        }

        [DebuggerStepThrough] public static RG16 operator -(RG16 lhs, RG16 rhs)
        {
            return (RG16) ((int2) lhs - (int2) rhs);
        }
    }
}
