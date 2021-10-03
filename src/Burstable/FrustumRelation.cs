namespace Appalachia.Core.Burstable
{
    public enum FrustumRelation
    {
        /// <summary>
        ///     The AABB is completely in the frustum.
        /// </summary>
        Inside = 0,

        /// <summary>
        ///     The AABB is partially in the frustum.
        /// </summary>
        Intersect,

        /// <summary>
        ///     The AABB is completely outside the frustum.
        /// </summary>
        Outside
    }
}
