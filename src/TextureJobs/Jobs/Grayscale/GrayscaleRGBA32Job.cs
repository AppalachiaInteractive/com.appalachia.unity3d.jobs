using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Collections;
using Unity.Mathematics;

namespace Appalachia.Jobs.TextureJobs.Jobs.Grayscale
{
    [Unity.Burst.BurstCompile]
    public struct GrayscaleRGBA32Job : Unity.Jobs.IJobParallelFor
    {
        #region Fields and Autoproperties

        public NativeArray<RGBA32> data;

        #endregion

        #region IJobParallelFor Members

        void Unity.Jobs.IJobParallelFor.Execute(int i)
        {
            var color = data[i];
            var product = math.mul(
                new float3 { x = color.R, y = color.G, z = color.B },
                new float3 { x = 0.3f, y = 0.59f, z = 0.11f }
            );
            var b = (byte)product;
            data[i] = new RGBA32
            {
                R = b,
                G = b,
                B = b,
                A = color.A
            };
        }

        #endregion
    }
}
