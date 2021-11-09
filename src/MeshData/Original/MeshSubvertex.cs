/*using System;
using UnityEngine;

namespace Appalachia.Jobs.MeshData
{
    [Serializable]
    public class MeshSubvertex : IEquatable<MeshSubvertex>
    {
        public Vector3 normal;

        public short index;

        [DebuggerStepThrough] public bool Equals(MeshSubvertex other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return normal.Equals(other.normal) && index == other.index;
        }

        [DebuggerStepThrough] public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((MeshSubvertex) obj);
        }

        [DebuggerStepThrough] public override int GetHashCode()
        {
            unchecked
            {
                return (normal.GetHashCode() * 397) ^ (int)index;
            }
        }

        [DebuggerStepThrough] public static bool operator ==(MeshSubvertex left, MeshSubvertex right)
        {
            return Equals(left, right);
        }

        [DebuggerStepThrough] public static bool operator !=(MeshSubvertex left, MeshSubvertex right)
        {
            return !Equals(left, right);
        }
    }
}*/


