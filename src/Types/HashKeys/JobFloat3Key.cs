#region

using System;
using System.Diagnostics;
using Unity.Mathematics;

#endregion

namespace Appalachia.Jobs.Types.HashKeys
{
    public struct JobFloat3Key : IEquatable<JobFloat3Key>
    {
#region Constructor

        public JobFloat3Key(float3 position, int groupScale)
        {
            x = (int) math.round(position.x * groupScale);
            y = (int) math.round(position.y * groupScale);
            z = (int) math.round(position.z * groupScale);
            this.groupScale = groupScale;

            _hashCode = CalculateHashCode(x, y, z);
        }

#endregion

        private readonly int _hashCode;
        private readonly int x;
        private readonly int y;
        private readonly int z;
        private readonly int groupScale;

#region Hashing

        public static int CalculateHashCode(float3 position, int groupScale)
        {
            unchecked
            {
                var hashCode = math.round(position.x * groupScale).GetHashCode();
                hashCode = (hashCode * 397) ^ math.round(position.y * groupScale).GetHashCode();
                hashCode = (hashCode * 397) ^ math.round(position.z * groupScale).GetHashCode();
                return hashCode;
            }
        }

        public static int CalculateHashCode(int x, int y, int z)
        {
            unchecked
            {
                var hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                return hashCode;
            }
        }

#endregion

#region IEquatable<JobFloat3Key>

        [DebuggerStepThrough] public bool Equals(JobFloat3Key other)
        {
            return (x == other.x) &&
                   (y == other.y) &&
                   (z == other.z) &&
                   (groupScale == other.groupScale);
        }

        [DebuggerStepThrough] public override bool Equals(object obj)
        {
            return obj is JobFloat3Key other && Equals(other);
        }

        [DebuggerStepThrough] public override int GetHashCode()
        {
            return _hashCode;
        }

        [DebuggerStepThrough] public static bool operator ==(JobFloat3Key left, JobFloat3Key right)
        {
            return left.Equals(right);
        }

        [DebuggerStepThrough] public static bool operator !=(JobFloat3Key left, JobFloat3Key right)
        {
            return !left.Equals(right);
        }

#endregion
    }
}
