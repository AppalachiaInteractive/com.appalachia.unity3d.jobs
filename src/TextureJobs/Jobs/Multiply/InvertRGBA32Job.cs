using Appalachia.CI.Integration.Attributes;
using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Collections;
using UnityEngine;

namespace Appalachia.Jobs.TextureJobs.Jobs.Multiply
{
    [Unity.Burst.BurstCompile]
    [DoNotReorderFields]
    public struct MultiplyRGBA32Job : Unity.Jobs.IJobParallelFor
    {
        public MultiplyRGBA32Job(NativeArray<RGBA32> data, Color multiplyBy)
        {
            this.data = data;
            r = (byte)(int)(multiplyBy.r * byte.MaxValue);
            g = (byte)(int)(multiplyBy.g * byte.MaxValue);
            b = (byte)(int)(multiplyBy.b * byte.MaxValue);
            a = (byte)(int)(multiplyBy.a * byte.MaxValue);
        }

        #region Fields and Autoproperties

        public NativeArray<RGBA32> data;
        private readonly byte r;
        private readonly byte b;
        private readonly byte g;
        private readonly byte a;

        #endregion

        private byte Multiply(byte b, byte channel)
        {
            var i = (int)b;
            var c = (int)channel;
            var v = (i * c) / byte.MaxValue;

            return (byte)v;
        }

        #region IJobParallelFor Members

        void Unity.Jobs.IJobParallelFor.Execute(int i)
        {
            var color = data[i];
            data[i] = new RGBA32
            {
                R = Multiply(color.R, r),
                G = Multiply(color.G, g),
                B = Multiply(color.B, b),
                A = Multiply(color.A, a),
            };
        }

        #endregion
    }
}
