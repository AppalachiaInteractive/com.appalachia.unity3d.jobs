#region

using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

#endregion

namespace Appalachia.Core.Burstable
{
    public struct FrustumPlanesBurst : IEquatable<FrustumPlanesBurst>
    {
        public FrustumPlanesBurst(Plane[] planes)
        {
            left = new PlaneBurst(planes[0]);
            right = new PlaneBurst(planes[1]);
            down = new PlaneBurst(planes[2]);
            up = new PlaneBurst(planes[3]);
            near = new PlaneBurst(planes[4]);
            far = new PlaneBurst(planes[5]);
        }

        public PlaneBurst left;
        public PlaneBurst right;
        public PlaneBurst down;
        public PlaneBurst up;
        public PlaneBurst near;
        public PlaneBurst far;

        public PlaneBurst this[FrustumPlanePart part] => this[(int) part];

        public PlaneBurst this[int i] =>
            (i < 0) || (i > 5)
                ? throw new ArgumentOutOfRangeException()
                : i == 0
                    ? left
                    : i == 1
                        ? right
                        : i == 2
                            ? down
                            : i == 3
                                ? up
                                : i == 4
                                    ? near
                                    : far;

        [MethodImpl(MethodImplOptions.AggressiveInlining), BurstCompile]
        public bool Inside(BoundsBurst bounds)
        {
            return Test(bounds, false) == FrustumRelation.Inside;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining), BurstCompile]
        public bool Outside(BoundsBurst bounds)
        {
            return Test(bounds, false) == FrustumRelation.Outside;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining), BurstCompile]
        public bool Intersecting(BoundsBurst bounds)
        {
            return Test(bounds, true) == FrustumRelation.Intersect;
        }

        [BurstCompile]
        private FrustumRelation Test(BoundsBurst bounds, bool testIntersection)
        {
            float3 vmin;
            float3 vmax;

            var testResult = FrustumRelation.Inside;

            for (var planeIndex = 0; planeIndex < 6; planeIndex++)
            {
                var normal = this[planeIndex].normal;
                var planeDistance = this[planeIndex].distance;

                // X axis
                if (normal.x < 0)
                {
                    vmin.x = bounds.min.x;
                    vmax.x = bounds.max.x;
                }
                else
                {
                    vmin.x = bounds.max.x;
                    vmax.x = bounds.min.x;
                }

                // Y axis
                if (normal.y < 0)
                {
                    vmin.y = bounds.min.y;
                    vmax.y = bounds.max.y;
                }
                else
                {
                    vmin.y = bounds.max.y;
                    vmax.y = bounds.min.y;
                }

                // Z axis
                if (normal.z < 0)
                {
                    vmin.z = bounds.min.z;
                    vmax.z = bounds.max.z;
                }
                else
                {
                    vmin.z = bounds.max.z;
                    vmax.z = bounds.min.z;
                }

                var dot1 = (normal.x * vmin.x) + (normal.y * vmin.y) + (normal.z * vmin.z);

                if ((dot1 + planeDistance) < 0)
                {
                    return FrustumRelation.Outside;
                }

                if (testIntersection)
                {
                    var dot2 = (normal.x * vmax.x) + (normal.y * vmax.y) + (normal.z * vmax.z);
                    if ((dot2 + planeDistance) <= 0)
                    {
                        testResult = FrustumRelation.Intersect;
                    }
                }
            }

            return testResult;
        }

#region IEquatable

        public bool Equals(FrustumPlanesBurst other)
        {
            return left.Equals(other.left) &&
                   right.Equals(other.right) &&
                   down.Equals(other.down) &&
                   up.Equals(other.up) &&
                   near.Equals(other.near) &&
                   far.Equals(other.far);
        }

        public override bool Equals(object obj)
        {
            return obj is FrustumPlanesBurst other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = left.GetHashCode();
                hashCode = (hashCode * 397) ^ right.GetHashCode();
                hashCode = (hashCode * 397) ^ down.GetHashCode();
                hashCode = (hashCode * 397) ^ up.GetHashCode();
                hashCode = (hashCode * 397) ^ near.GetHashCode();
                hashCode = (hashCode * 397) ^ far.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(FrustumPlanesBurst left, FrustumPlanesBurst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FrustumPlanesBurst left, FrustumPlanesBurst right)
        {
            return !left.Equals(right);
        }

#endregion
    }
}
