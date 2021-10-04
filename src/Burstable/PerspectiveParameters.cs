namespace Appalachia.Jobs.Burstable
{
    /// <summary>
    ///     Data describing a projection matrix.
    /// </summary>
    public struct PerspectiveParameters
    {
        /// <param name="fov">Vertical field-of-view in degrees.</param>
        public float fov;

        /// <param name="aspect">Aspect ratio (width divided by height).</param>
        public float aspect;

        /// <param name="zNear">Near depth clipping plane value.</param>
        public float zNear;

        /// <param name="zFar">Far depth clipping plane value.</param>
        public float zFar;
    }
}
