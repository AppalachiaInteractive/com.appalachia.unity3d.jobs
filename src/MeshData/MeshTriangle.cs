#region

using System;
using System.Diagnostics;

#endregion

namespace Appalachia.Jobs.MeshData
{
    public struct MeshTriangle : IEquatable<MeshTriangle>
    {
#region Constructor

        public MeshTriangle(
            int index,
            int originalXIndex,
            int originalYIndex,
            int originalZIndex,
            int xIndex,
            int yIndex,
            int zIndex)
        {
            this.index = index;
            this.originalXIndex = originalXIndex;
            this.originalYIndex = originalYIndex;
            this.originalZIndex = originalZIndex;
            this.xIndex = xIndex;
            this.yIndex = yIndex;
            this.zIndex = zIndex;
        }

#endregion

        public readonly int index;
        public readonly int originalXIndex;
        public readonly int originalYIndex;
        public readonly int originalZIndex;
        public readonly int xIndex;
        public readonly int yIndex;
        public readonly int zIndex;

#region IEquatable<MeshTriangle>

        [DebuggerStepThrough] public bool Equals(MeshTriangle other)
        {
            return (xIndex == other.xIndex) && (yIndex == other.yIndex) && (zIndex == other.zIndex);
        }

        [DebuggerStepThrough] public override bool Equals(object obj)
        {
            return obj is MeshTriangle other && Equals(other);
        }

        [DebuggerStepThrough] public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = xIndex.GetHashCode();
                hashCode = (hashCode * 397) ^ yIndex.GetHashCode();
                hashCode = (hashCode * 397) ^ zIndex.GetHashCode();
                return hashCode;
            }
        }

        [DebuggerStepThrough] public static bool operator ==(MeshTriangle left, MeshTriangle right)
        {
            return left.Equals(right);
        }

        [DebuggerStepThrough] public static bool operator !=(MeshTriangle left, MeshTriangle right)
        {
            return !left.Equals(right);
        }

#endregion
    }
}
