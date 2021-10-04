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
    public struct PlaneBurst : IEquatable<PlaneBurst>
    {
        internal const int size = 16;

        /// <summary>
        ///     <para>Normal vector of the plane.</para>
        /// </summary>
        [SerializeField]
        public float3 normal;

        /// <summary>
        ///     <para>A point on the plane.</para>
        /// </summary>
        [SerializeField]
        public float3 point;

        /// <summary>
        ///     <para>Distance from the origin to the plane.</para>
        /// </summary>
        [SerializeField]
        public float distance;

        public PlaneBurst(Plane plane)
        {
            normal = plane.normal;
            distance = plane.distance;
            point = plane.normal * plane.distance;
        }

        /// <summary>
        ///     <para>Creates a plane.</para>
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="inPoint"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PlaneBurst(float3 normal, float3 inPoint)
        {
            this.normal = math.normalize(normal);
            distance = -math.dot(this.normal, inPoint);
            point = inPoint;
        }

        /// <summary>
        ///     <para>Creates a plane.</para>
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="d"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PlaneBurst(float3 normal, float d)
        {
            this.normal = math.normalize(normal);
            distance = d;
            point = normal * distance;
        }

        /// <summary>
        ///     <para>Creates a plane.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PlaneBurst(float3 a, float3 b, float3 c)
        {
            normal = math.normalize(math.cross(b - a, c - a));
            distance = -math.dot(normal, a);
            point = normal * distance;
        }

        /// <summary>
        ///     <para>Returns a copy of the plane that faces in the opposite direction.</para>
        /// </summary>
        public Plane flipped => new(-normal, -distance);

        /// <summary>
        ///     <para>Sets a plane using a point that lies within it along with a normal to orient it.</para>
        /// </summary>
        /// <param name="normal">The plane's normal vector.</param>
        /// <param name="point">A point that lies on the plane.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void SetNormalAndPosition(float3 normal, float3 point)
        {
            this.normal = math.normalize(normal);
            distance = -math.dot(normal, point);
            this.point = point;
        }

        /// <summary>
        ///     <para>Sets a plane using three points that lie within it.  The points go around clockwise as you look down on the top surface of the plane.</para>
        /// </summary>
        /// <param name="a">First point in clockwise order.</param>
        /// <param name="b">Second point in clockwise order.</param>
        /// <param name="c">Third point in clockwise order.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Set3Points(float3 a, float3 b, float3 c)
        {
            normal = math.normalize(math.cross(b - a, c - a));
            distance = -math.dot(normal, a);
            point = normal * distance;
        }

        /// <summary>
        ///     <para>Makes the plane face in the opposite direction.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Flip()
        {
            normal = -normal;
            distance = -distance;
        }

        /// <summary>
        ///     <para>Moves the plane in space by the translation vector.</para>
        /// </summary>
        /// <param name="translation">The offset in space to move the plane with.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public void Translate(float3 translation)
        {
            distance += math.dot(normal, translation);
            point = normal * distance;
        }

        /// <summary>
        ///     <para>Returns a copy of the given plane that is moved in space by the given translation.</para>
        /// </summary>
        /// <param name="plane">The plane to move in space.</param>
        /// <param name="translation">The offset in space to move the plane with.</param>
        /// <returns>
        ///     <para>The translated plane.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public static Plane Translate(PlaneBurst plane, float3 translation)
        {
            return new(plane.normal, plane.distance += math.dot(plane.normal, translation));
        }

        /// <summary>
        ///     <para>For a given point returns the closest point on the plane.</para>
        /// </summary>
        /// <param name="point">The point to project onto the plane.</param>
        /// <returns>
        ///     <para>A point on the plane that is closest to point.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public float3 ClosestPointOnPlane(float3 point)
        {
            var num = math.dot(normal, point) + distance;
            return point - (normal * num);
        }

        /// <summary>
        ///     <para>Returns a signed distance from plane to point.</para>
        /// </summary>
        /// <param name="point"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public float GetDistanceToPoint(float3 point)
        {
            return math.dot(normal, point) + distance;
        }

        /// <summary>
        ///     <para>Is a point on the positive side of the plane?</para>
        /// </summary>
        /// <param name="point"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool GetSide(float3 point)
        {
            return (math.dot(normal, point) + (double) distance) > 0.0;
        }

        /// <summary>
        ///     <para>Are two points on the same side of the plane?</para>
        /// </summary>
        /// <param name="inPt0"></param>
        /// <param name="inPt1"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool SameSide(float3 inPt0, float3 inPt1)
        {
            var distanceToPoint1 = GetDistanceToPoint(inPt0);
            var distanceToPoint2 = GetDistanceToPoint(inPt1);
            return ((distanceToPoint1 > 0.0) && (distanceToPoint2 > 0.0)) ||
                   ((distanceToPoint1 <= 0.0) && (distanceToPoint2 <= 0.0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool Raycast(Ray ray, out float enter)
        {
            var a = math.dot(ray.direction, normal);
            var num = -math.dot(ray.origin, normal) - distance;
            if (math.abs(a) < .000001f)
            {
                enter = 0.0f;
                return false;
            }

            enter = num / a;
            return enter > 0.0;
        }

        /// <summary>
        ///     Find the line of intersection between two planes.	The planes are defined by a normal and a point on that plane.
        ///     The outputs are a point on the line and a vector which indicates it's direction. If the planes are not parallel,
        ///     the function outputs true, otherwise false.
        /// </summary>
        /// <param name="linePoint"></param>
        /// <param name="lineVec"></param>
        /// <param name="plane2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [BurstCompile]
        public bool PlanePlaneIntersection(
            out float3 linePoint,
            out float3 lineVec,
            PlaneBurst plane2)
        {
            linePoint = float3.zero;
            lineVec = float3.zero;

            //We can get the direction of the line of intersection of the two planes by calculating the 
            //cross product of the normals of the two planes. Note that this is just a direction and the line
            //is not fixed in space yet. We need a point for that to go with the line vector.
            lineVec = math.cross(normal, plane2.normal);

            //Next is to calculate a point on the line to fix it's position in space. This is done by finding a vector from
            //the plane2 location, moving parallel to it's plane, and intersecting plane1. To prevent rounding
            //errors, this vector also has to be perpendicular to lineDirection. To get this vector, calculate
            //the cross product of the normal of plane2 and the lineDirection.		
            var ldir = math.cross(plane2.normal, lineVec);

            var denominator = math.dot(normal, ldir);

            //Prevent divide by zero and rounding errors by requiring about 5 degrees angle between the planes.
            if (math.abs(denominator) > 0.006f)
            {
                var plane1ToPlane2 = point - plane2.point;
                var t = math.dot(normal, plane1ToPlane2) / denominator;
                linePoint = plane2.point + (t * ldir);

                return true;
            }

            //output not valid
            return false;
        }

        /// <summary>
        ///     Get the intersection between a line and a plane.
        ///     If the line and plane are not parallel, the function outputs true, otherwise false.
        /// </summary>
        /// <param name="intersection"></param>
        /// <param name="linePoint"></param>
        /// <param name="lineVec"></param>
        /// <returns></returns>
        public bool LinePlaneIntersection(out float3 intersection, float3 linePoint, float3 lineVec)
        {
            intersection = float3.zero;

            //calculate the distance between the linePoint and the line-plane intersection point
            var dotNumerator = math.dot(point - linePoint, normal);
            var dotDenominator = math.dot(lineVec,         normal);

            //line and plane are parallel
            if (dotDenominator == 0.0f)
            {
                return false;
            }

            var length = dotNumerator / dotDenominator;

            //create a vector from the linePoint to the intersection point
            var vector = lineVec * length;

            //get the coordinates of the line-plane intersection point
            intersection = linePoint + vector;

            return true;
        }

#region ToString

        [BurstDiscard]
        public string ToShortString()
        {
            return $"(n:({normal.x:F1}, {normal.y:F1}, {normal.z:F1}), d:{distance:F1})";
        }

        [BurstDiscard]
        public override string ToString()
        {
            return
                $"(normal:({normal.x:F1}, {normal.y:F1}, {normal.z:F1}), distance:{distance:F1})";
        }

        [BurstDiscard]
        public string ToString(string format)
        {
            return
                $"(normal:({normal.x.ToString(format)}, {normal.y.ToString(format)}, {normal.z.ToString(format)}), distance:{distance.ToString(format)})";
        }

#endregion

#region IEquatable

        public bool Equals(PlaneBurst other)
        {
            return normal.Equals(other.normal) && distance.Equals(other.distance);
        }

        public override bool Equals(object obj)
        {
            return obj is PlaneBurst other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (normal.GetHashCode() * 397) ^ distance.GetHashCode();
            }
        }

        public static bool operator ==(PlaneBurst left, PlaneBurst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlaneBurst left, PlaneBurst right)
        {
            return !left.Equals(right);
        }

#endregion
    }
}
