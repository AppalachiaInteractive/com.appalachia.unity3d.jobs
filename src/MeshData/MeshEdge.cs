#region

using System;
using System.Diagnostics;

#endregion

namespace Appalachia.Jobs.MeshData
{
    public struct MeshEdge : IEquatable<MeshEdge>
    {
#region Constructor

        public MeshEdge(int aIndex, int bIndex)
        {
            this.aIndex = aIndex;
            this.bIndex = bIndex;
            triangleCount = 0;
        }

        public MeshEdge(int aIndex, int bIndex, int triangleCount)
        {
            this.aIndex = aIndex;
            this.bIndex = bIndex;
            this.triangleCount = triangleCount;
        }

#endregion

        public readonly int aIndex;
        public readonly int bIndex;
        public readonly int triangleCount;

#region IEquatable<MeshEdge>

        [DebuggerStepThrough] public bool Equals(MeshEdge other)
        {
            return ((aIndex == other.aIndex) && (bIndex == other.bIndex)) ||
                   ((aIndex == other.bIndex) && (bIndex == other.aIndex));
        }

        [DebuggerStepThrough] public override bool Equals(object obj)
        {
            return obj is MeshEdge other && Equals(other);
        }

        [DebuggerStepThrough] public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (aIndex * 397) ^ bIndex;
                hashCode += (bIndex * 397) ^ aIndex;

                return hashCode;
            }
        }

        [DebuggerStepThrough] public static bool operator ==(MeshEdge left, MeshEdge right)
        {
            return left.Equals(right);
        }

        [DebuggerStepThrough] public static bool operator !=(MeshEdge left, MeshEdge right)
        {
            return !left.Equals(right);
        }

#endregion
    }
}
