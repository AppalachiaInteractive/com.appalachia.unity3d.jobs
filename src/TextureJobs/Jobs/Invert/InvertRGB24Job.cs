using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Collections;

namespace Appalachia.Jobs.TextureJobs.Jobs.Invert
{
    [Unity.Burst.BurstCompile]
    public struct InvertRGB24Job : Unity.Jobs.IJobParallelFor
    {
        #region Fields and Autoproperties

        public NativeArray<RGB24> data;

        #endregion

        private byte Invert(byte b)
        {
            return (byte)(byte.MaxValue - b);
        }

        #region IJobParallelFor Members

        void Unity.Jobs.IJobParallelFor.Execute(int i)
        {
            var color = data[i];
            data[i] = new RGB24 { R = Invert(color.R), G = Invert(color.G), B = Invert(color.B) };
        }

        #endregion
    }
}
