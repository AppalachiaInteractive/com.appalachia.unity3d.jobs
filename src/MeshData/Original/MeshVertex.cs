/*using System;
using Appalachia.Core.HashKeys;
using Unity.Mathematics;

namespace Appalachia.Jobs.MeshData
{
    public struct MeshVertex : IEquatable<MeshVertex>
    {
        #region Constructor

        public MeshVertex(float3 position, int groupingScale, int originalIndex, int newIndex) : this(
            position,
            new JobFloat3Key(position, groupingScale),
            originalIndex,
            newIndex
        )
        {
        }

        public MeshVertex(float3 position, JobFloat3Key key, int originalIndex, int newIndex)
        {
            this.key = key;
            this.position = position;
            this.originalIndex = originalIndex;
            this.newIndex = newIndex;
        }

        #endregion

        public readonly JobFloat3Key key;
        public readonly float3 position;
        public readonly int originalIndex;
        public readonly int newIndex;

        #region IEquatable<MeshVertex>

        [DebuggerStepThrough] public bool Equals(MeshVertex other)
        {
            return key.Equals(other.key);
        }

        [DebuggerStepThrough] public override bool Equals(object obj)
        {
            return obj is MeshVertex other && Equals(other);
        }

        [DebuggerStepThrough] public override int GetHashCode()
        {
            return key.GetHashCode();
        }

        [DebuggerStepThrough] public static bool operator ==(MeshVertex left, MeshVertex right)
        {
            return left.Equals(right);
        }

        [DebuggerStepThrough] public static bool operator !=(MeshVertex left, MeshVertex right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}*/


