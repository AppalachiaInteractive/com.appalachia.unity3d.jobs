using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Collections;
using Unity.Mathematics;

// src: http://blog.ivank.net/fastest-gaussian-blur.html

namespace Appalachia.Jobs.TextureJobs.Jobs.BoxBlur
{
    [Unity.Burst.BurstCompile]
    public struct BoxBlurRGBA32Job : Unity.Jobs.IJob
    {
        public BoxBlurRGBA32Job(NativeArray<RGBA32> data, int texture_width, int texture_height, int radius)
        {
            results = data;
            copy = new NativeArray<RGBA32>(data, Allocator.TempJob);
            w = texture_width;
            h = texture_height;
            r = radius;
        }

        #region Fields and Autoproperties

        private readonly int w, h, r;

        [DeallocateOnJobCompletion]
        private NativeArray<RGBA32> copy;

        private NativeArray<RGBA32> results;

        #endregion

        private void BoxBlurHorizontal(NativeArray<RGBA32> src, NativeArray<RGBA32> dst)
        {
            var iarr = 1f / (r + r + 1);
            for (var i = 0; i < h; i++)
            {
                var ti = i * w;
                var li = ti;
                var ri = ti + r;
                float4 fv = (int4)src[ti];
                float4 lv = (int4)src[(ti + w) - 1];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++)
                {
                    val += (int4)src[ti + j];
                }

                for (var j = 0; j <= r; j++)
                {
                    val += (int4)src[ri++] - fv;
                    dst[ti++] = (RGBA32)(int4)math.round(val * iarr);
                }

                for (var j = r + 1; j < (w - r); j++)
                {
                    val += (int4)src[ri++] - (int4)src[li++];
                    dst[ti++] = (RGBA32)(int4)math.round(val * iarr);
                }

                for (var j = w - r; j < w; j++)
                {
                    val += lv - (int4)src[li++];
                    dst[ti++] = (RGBA32)(int4)math.round(val * iarr);
                }
            }
        }

        private void BoxBlurTotal(NativeArray<RGBA32> src, NativeArray<RGBA32> dst)
        {
            float4 iarr = 1f / (r + r + 1);
            for (var i = 0; i < w; i++)
            {
                var ti = i;
                var li = ti;
                var ri = ti + (r * w);
                float4 fv = (int4)src[ti];
                float4 lv = (int4)src[ti + (w * (h - 1))];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++)
                {
                    val += (int4)src[ti + (j * w)];
                }

                for (var j = 0; j <= r; j++)
                {
                    val += (int4)src[ri] - fv;
                    dst[ti] = (RGBA32)(int4)math.round(val * iarr);
                    ri += w;
                    ti += w;
                }

                for (var j = r + 1; j < (h - r); j++)
                {
                    val += (int4)src[ri] - (int4)src[li];
                    dst[ti] = (RGBA32)(int4)math.round(val * iarr);
                    li += w;
                    ri += w;
                    ti += w;
                }

                for (var j = h - r; j < h; j++)
                {
                    val += lv - (int4)src[li];
                    dst[ti] = (RGBA32)(int4)math.round(val * iarr);
                    li += w;
                    ti += w;
                }
            }
        }

        #region IJob Members

        void Unity.Jobs.IJob.Execute()
        {
            BoxBlurHorizontal(results, copy);
            BoxBlurTotal(copy, results);
        }

        #endregion
    }
}
