using Unity.Collections;

namespace Appalachia.Jobs.TextureJobs.Jobs.Invert
{
    [Unity.Burst.BurstCompile]
    public struct InvertR16Job : Unity.Jobs.IJobParallelFor
    {
        #region Fields and Autoproperties

        public NativeArray<ushort> data;

        #endregion

        #region IJobParallelFor Members

        void Unity.Jobs.IJobParallelFor.Execute(int i)
        {
            data[i] = (ushort)(ushort.MaxValue - data[i]);
        }

        #endregion
    }
}
