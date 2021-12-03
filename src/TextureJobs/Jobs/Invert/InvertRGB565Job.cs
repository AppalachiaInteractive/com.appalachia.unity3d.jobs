using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Collections;

namespace Appalachia.Jobs.TextureJobs.Jobs.Invert
{
    [Unity.Burst.BurstCompile]
    public struct InvertRGB565Job : Unity.Jobs.IJobParallelFor
    {
        #region Fields and Autoproperties

        public NativeArray<RGB565> data;

        #endregion

        private byte Invert(byte b)
        {
            return (byte)(byte.MaxValue - b);
        }

        #region IJobParallelFor Members

        void Unity.Jobs.IJobParallelFor.Execute(int i)
        {
            var value = data[i];
            data[i] = new RGB565(Invert(value.R), Invert(value.G), Invert(value.B));
        }

        #endregion
    }
}
