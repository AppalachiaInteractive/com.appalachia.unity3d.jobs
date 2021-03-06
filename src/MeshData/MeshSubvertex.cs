#region

using System;
using System.Diagnostics;
using Appalachia.Jobs.Types.HashKeys;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.MeshData
{
    public struct MeshSubvertex : IEquatable<MeshSubvertex>
    {
#region Constructor

        public MeshSubvertex(float3 normal, int groupingScale, int originalIndex)
        {
            this.normal = normal;
            key = new JobFloat3Key(normal, groupingScale);
            this.originalIndex = originalIndex;
        }

#endregion

        public readonly JobFloat3Key key;
        public readonly float3 normal;
        public readonly int originalIndex;

#region IEquatable<MeshSubvertex>

        [DebuggerStepThrough] public bool Equals(MeshSubvertex other)
        {
            return key.Equals(other.key);
        }

        [DebuggerStepThrough] public override bool Equals(object obj)
        {
            return obj is MeshSubvertex other && Equals(other);
        }

        [DebuggerStepThrough] public override int GetHashCode()
        {
            return key.GetHashCode();
        }

        [DebuggerStepThrough] public static bool operator ==(MeshSubvertex left, MeshSubvertex right)
        {
            return left.Equals(right);
        }

        [DebuggerStepThrough] public static bool operator !=(MeshSubvertex left, MeshSubvertex right)
        {
            return !left.Equals(right);
        }

#endregion
    }
}
