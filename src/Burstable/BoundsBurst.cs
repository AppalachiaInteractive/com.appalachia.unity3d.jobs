#region

using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.Burstable
{
    [Serializable]
    public struct BoundsBurst : IEquatable<Bounds>
    {
        [SerializeField] public float3 center;
        [SerializeField] public float3 extents;
        [SerializeField] public float3 min;
        [SerializeField] public float3 max;
        [SerializeField] public float3 size;

        /// <summary>
        ///     <para>Creates a new Bounds from an existing one.</para>
        /// </summary>
        /// <param name="b">The original bounds.</param>
        public BoundsBurst(Bounds b)
        {
            center = b.center;
            extents = b.extents;
            min = center - extents;
            max = center + extents;
            size = extents * 2;
        }

        /// <summary>
        ///     <para>Creates a new Bounds.</para>
        /// </summary>
        /// <param name="center">The location of the origin of the Bounds.</param>
        /// <param name="size">The dimensions of the Bounds.</param>
        public BoundsBurst(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
            extents = size * 0.5f;
            min = this.center - extents;
            max = this.center + extents;
        }

        /// <summary>
        ///     <para>Creates a new Bounds.</para>
        /// </summary>
        /// <param name="center">The location of the origin of the Bounds.</param>
        /// <param name="size">The dimensions of the Bounds.</param>
        public BoundsBurst(float3 center, float3 size)
        {
            this.center = center;
            this.size = size;
            extents = size * 0.5f;
            min = this.center - extents;
            max = this.center + extents;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Shift(float3 shift, float3 scale)
        {
            center += shift;
            min += shift;
            max += shift;
            size *= scale;
        }

        /// <summary>
        ///     <para>Sets the bounds to the min and max value of the box.</para>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void SetMinMax(float3 min, float3 max)
        {
            extents = (max - min) * 0.5f;
            center = min + extents;
        }

        /// <summary>
        ///     <para>Grows the Bounds to include the point.</para>
        /// </summary>
        /// <param name="point"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Encapsulate(float3 point)
        {
            SetMinMax(math.min(min, point), math.max(max, point));
        }

        /// <summary>
        ///     <para>Grow the bounds to encapsulate the bounds.</para>
        /// </summary>
        /// <param name="bounds"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Encapsulate(BoundsBurst bounds)
        {
            Encapsulate(bounds.max);
            Encapsulate(bounds.min);
        }

        /// <summary>
        ///     <para>Grow the bounds to encapsulate the bounds.</para>
        /// </summary>
        /// <param name="bounds"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Encapsulate(Bounds bounds)
        {
            var c = bounds.center;
            var ex = bounds.extents;

            Encapsulate(c - ex);
            Encapsulate(c + ex);
        }

        /// <summary>
        ///     <para>Expand the bounds by increasing its size by amount along each side.</para>
        /// </summary>
        /// <param name="amount"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Expand(float amount)
        {
            amount *= 0.5f;
            extents += new float3(amount, amount, amount);
        }

        /// <summary>
        ///     <para>Expand the bounds by increasing its size by amount along each side.</para>
        /// </summary>
        /// <param name="amount"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Expand(float3 amount)
        {
            extents += amount * 0.5f;
        }

        /// <summary>
        ///     <para>Does another bounding box intersect with this bounding box?</para>
        /// </summary>
        /// <param name="bounds"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool Intersects(BoundsBurst bounds)
        {
            return (min.x <= (double) bounds.max.x) &&
                   (max.x >= (double) bounds.min.x) &&
                   (min.y <= (double) bounds.max.y) &&
                   (max.y >= (double) bounds.min.y) &&
                   (min.z <= (double) bounds.max.z) &&
                   (max.z >= (double) bounds.min.z);
        }

        /// <summary>
        ///     <para>Does another bounding box intersect with this bounding box?</para>
        /// </summary>
        /// <param name="bounds"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool Intersects(Bounds bounds)
        {
            return (min.x <= (double) bounds.max.x) &&
                   (max.x >= (double) bounds.min.x) &&
                   (min.y <= (double) bounds.max.y) &&
                   (max.y >= (double) bounds.min.y) &&
                   (min.z <= (double) bounds.max.z) &&
                   (max.z >= (double) bounds.min.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool Contains(Vector3 v)
        {
            return (v.x >= min.x) &&
                   (v.x <= max.x) &&
                   (v.y >= min.y) &&
                   (v.y <= max.y) &&
                   (v.z >= min.z) &&
                   (v.z <= max.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool Contains(BoundsBurst b)
        {
            return Contains(b.min) && Contains(b.max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool Contains(Bounds b)
        {
            return Contains(b.min) && Contains(b.max);
        }

        [BurstCompile]
        public static implicit operator Bounds(BoundsBurst b)
        {
            return new(b.center, b.size);
        }

        [BurstCompile]
        public static implicit operator BoundsBurst(Bounds b)
        {
            return new(b.center, b.size);
        }

        /// <summary>
        ///     <para>Returns a nicely formatted string for the bounds.</para>
        /// </summary>
        /// <param name="format"></param>
        public override string ToString()
        {
            return string.Format("Center: {0}, Extents: {1}", center, extents);
        }

#region IEquatable

        public override int GetHashCode()
        {
            var vector3 = center;
            var hashCode = vector3.GetHashCode();
            vector3 = extents;
            var num = vector3.GetHashCode() << 2;
            return hashCode ^ num;
        }

        public override bool Equals(object other)
        {
            if (other is BoundsBurst other1)
            {
                return Equals(other1);
            }

            if (other is Bounds b)
            {
                return Equals(b);
            }

            return false;
        }

        public bool Equals(Bounds other)
        {
            return center.Equals(other.center) && extents.Equals(other.extents);
        }

        public static bool operator ==(Bounds lhs, BoundsBurst rhs)
        {
            return lhs.center.Equals(rhs.center) && lhs.extents.Equals(rhs.extents);
        }

        public static bool operator !=(Bounds lhs, BoundsBurst rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator ==(BoundsBurst lhs, Bounds rhs)
        {
            return lhs.center.Equals(rhs.center) && lhs.extents.Equals(rhs.extents);
        }

        public static bool operator !=(BoundsBurst lhs, Bounds rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(BoundsBurst other)
        {
            return center.Equals(other.center) && extents.Equals(other.extents);
        }

        public static bool operator ==(BoundsBurst lhs, BoundsBurst rhs)
        {
            return lhs.center.Equals(rhs.center) && lhs.extents.Equals(rhs.extents);
        }

        public static bool operator !=(BoundsBurst lhs, BoundsBurst rhs)
        {
            return !(lhs == rhs);
        }

#endregion
    }
}
