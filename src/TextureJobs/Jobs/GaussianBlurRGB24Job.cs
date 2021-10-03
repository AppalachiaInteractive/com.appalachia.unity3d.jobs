#region

using Appalachia.Core.Globals.Jobs.TextureJobs.Structures;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

#endregion

// src: http://blog.ivank.net/fastest-gaussian-blur.html

namespace Appalachia.Core.Globals.Jobs.TextureJobs.Jobs
{
    [BurstCompile]
    public struct GaussianBlurRGB24Job : IJob
    {
        [DeallocateOnJobCompletion]
        private NativeArray<RGB24> copy;

        private NativeArray<RGB24> results;
        private readonly int w, h;
        private readonly float sigma;

        [DeallocateOnJobCompletion]
        private NativeArray<float> boxes;

        public GaussianBlurRGB24Job(NativeArray<RGB24> data, int texture_width, int texture_height, float sigma)
        {
            results = data;
            copy = new NativeArray<RGB24>(data, Allocator.Persistent);
            w = texture_width;
            h = texture_height;
            boxes = new NativeArray<float>(3, Allocator.Persistent);
            this.sigma = sigma;
        }

        void IJob.Execute()
        {
            BoxesForGauss(sigma, boxes);
            BoxBlur(copy,    results, (int) ((boxes[0] - 1f) / 2f));
            BoxBlur(results, copy,    (int) ((boxes[1] - 1f) / 2f));
            BoxBlur(copy,    results, (int) ((boxes[2] - 1f) / 2f));
        }

        private void BoxBlur(NativeArray<RGB24> src, NativeArray<RGB24> dst, int r)
        {
            BoxBlurHorizontal(dst, src, r);
            BoxBlurTotal(src, dst, r);
        }

        private void BoxBlurHorizontal(NativeArray<RGB24> src, NativeArray<RGB24> dst, int r)
        {
            var iarr = 1f / (r + r + 1);
            for (var i = 0; i < h; i++)
            {
                var ti = i * w;
                var li = ti;
                var ri = ti + r;
                float3 fv = (int3) src[ti];
                float3 lv = (int3) src[(ti + w) - 1];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++)
                {
                    val += (int3) src[ti + j];
                }

                for (var j = 0; j <= r; j++)
                {
                    val += (int3) src[ri++] - fv;
                    dst[ti++] = (RGB24) (int3) math.round(val * iarr);
                }

                for (var j = r + 1; j < (w - r); j++)
                {
                    val += (int3) src[ri++] - (int3) src[li++];
                    dst[ti++] = (RGB24) (int3) math.round(val * iarr);
                }

                for (var j = w - r; j < w; j++)
                {
                    val += lv - (int3) src[li++];
                    dst[ti++] = (RGB24) (int3) math.round(val * iarr);
                }
            }
        }

        private void BoxBlurTotal(NativeArray<RGB24> src, NativeArray<RGB24> dst, int r)
        {
            float3 iarr = 1f / (r + r + 1);
            for (var i = 0; i < w; i++)
            {
                var ti = i;
                var li = ti;
                var ri = ti + (r * w);
                float3 fv = (int3) src[ti];
                float3 lv = (int3) src[ti + (w * (h - 1))];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++)
                {
                    val += (int3) src[ti + (j * w)];
                }

                for (var j = 0; j <= r; j++)
                {
                    val += (int3) src[ri] - fv;
                    dst[ti] = (RGB24) (int3) math.round(val * iarr);
                    ri += w;
                    ti += w;
                }

                for (var j = r + 1; j < (h - r); j++)
                {
                    val += (int3) src[ri] - (int3) src[li];
                    dst[ti] = (RGB24) (int3) math.round(val * iarr);
                    li += w;
                    ri += w;
                    ti += w;
                }

                for (var j = h - r; j < h; j++)
                {
                    val += lv - (int3) src[li];
                    dst[ti] = (RGB24) (int3) math.round(val * iarr);
                    li += w;
                    ti += w;
                }
            }
        }

        private void BoxesForGauss(float sigma, NativeArray<float> boxes)
        {
            var n = boxes.Length;
            var wIdeal = math.sqrt(((12 * sigma * sigma) / n) + 1);
            var wl = math.floor(wIdeal);
            if ((wl % 2) == 0)
            {
                wl--;
            }

            var wu = wl + 2;

            var mIdeal = ((12 * sigma * sigma) - (n * wl * wl) - (4 * n * wl) - (3 * n)) / ((-4 * wl) - 4);
            var m = math.round(mIdeal);

            for (var i = 0; i < n; i++)
            {
                boxes[i] = i < m ? wl : wu;
            }
        }
    }
}
