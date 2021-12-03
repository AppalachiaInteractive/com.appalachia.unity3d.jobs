using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

// src: http://blog.ivank.net/fastest-gaussian-blur.html

namespace Appalachia.Jobs.TextureJobs.Jobs.GuassianChannelBlur
{
    [BurstCompile]
    public struct GaussianChannelBlurRGB48Job : IJob
    {
        public GaussianChannelBlurRGB48Job(
            NativeArray<RGB48> data,
            int texture_width,
            int texture_height,
            float sigma,
            int channel)
        {
            results = data;
            copy = new NativeArray<RGB48>(data, Allocator.TempJob);
            w = texture_width;
            h = texture_height;
            boxes = new NativeArray<float>(3, Allocator.TempJob);
            chan = channel;
            this.sigma = sigma;
        }

        #region Fields and Autoproperties

        private readonly float sigma;
        private readonly int chan;
        private readonly int w, h;

        [DeallocateOnJobCompletion]
        private readonly NativeArray<RGB48> copy;

        private readonly NativeArray<RGB48> results;

        [DeallocateOnJobCompletion]
        private NativeArray<float> boxes;

        #endregion

        private static RGB48 UpdateChannel(RGB48 newValue, RGB48 oldValue, int channel)
        {
            var result = oldValue;

            if (channel == 0)
            {
                result.R = newValue.R;
            }
            else if (channel == 1)
            {
                result.G = newValue.G;
            }
            else if (channel == 2)
            {
                result.B = newValue.B;
            }

            return result;
        }

        private void BoxBlur(NativeArray<RGB48> src, NativeArray<RGB48> dst, int r, int channel)
        {
            BoxBlurHorizontal(dst, src, r, channel);
            BoxBlurTotal(src, dst, r, channel);
        }

        private void BoxBlurHorizontal(NativeArray<RGB48> src, NativeArray<RGB48> dst, int r, int channel)
        {
            var iarr = 1f / (r + r + 1);

            for (var i = 0; i < h; i++)
            {
                var ti = i * w;
                var li = ti;
                var ri = ti + r;

                float3 fv = (half3)src[ti];

                var lv_0 = (ti + w) - 1;
                if (lv_0 >= src.Length)
                {
                    lv_0 -= 1;
                }

                float3 lv = (half3)src[lv_0];

                var val = (r + 1) * fv;

                for (var j = 0; j < r; j++)
                {
                    val += (half3)src[ti + j];
                }

                for (var j = 0; j <= r; j++)
                {
                    if ((ri >= (src.Length - 1)) || (ti >= (dst.Length - 1)))
                    {
                        continue;
                    }

                    val += (half3)src[ri++] - fv;

                    var newval = (RGB48)(half3)math.round(val * iarr);
                    var oldval = dst[ti];
                    newval = UpdateChannel(newval, oldval, channel);
                    dst[ti++] = newval;
                }

                for (var j = r + 1; j < (w - r); j++)
                {
                    if ((li >= (src.Length - 1)) || (ri >= (src.Length - 1)) || (ti >= (dst.Length - 1)))
                    {
                        continue;
                    }

                    val += (half3)(src[ri++] - src[li++]);

                    var newval = (RGB48)(half3)math.round(val * iarr);
                    var oldval = dst[ti];
                    newval = UpdateChannel(newval, oldval, channel);
                    dst[ti++] = newval;
                }

                for (var j = w - r; j < w; j++)
                {
                    if ((li >= (src.Length - 1)) || (ti >= (dst.Length - 1)))
                    {
                        continue;
                    }

                    val += lv - (half3)src[li++];

                    var newval = (RGB48)(half3)math.round(val * iarr);
                    var oldval = dst[ti];
                    newval = UpdateChannel(newval, oldval, channel);
                    dst[ti++] = newval;
                }
            }
        }

        private void BoxBlurTotal(NativeArray<RGB48> src, NativeArray<RGB48> dst, int r, int channel)
        {
            float3 iarr = 1f / (r + r + 1);
            for (var i = 0; i < w; i++)
            {
                var ti = i;
                var li = ti;
                var ri = ti + (r * w);
                float3 fv = (half3)src[ti];
                float3 lv = (half3)src[ti + (w * (h - 1))];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++)
                {
                    val += (half3)src[ti + (j * w)];
                }

                for (var j = 0; j <= r; j++)
                {
                    val += (half3)src[ri] - fv;

                    var newval = (RGB48)(half3)math.round(val * iarr);
                    var oldval = dst[ti];
                    newval = UpdateChannel(newval, oldval, channel);
                    dst[ti] = newval;

                    ri += w;
                    ti += w;
                }

                for (var j = r + 1; j < (h - r); j++)
                {
                    val += (half3)(src[ri] - src[li]);

                    var newval = (RGB48)(half3)math.round(val * iarr);
                    var oldval = dst[ti];
                    newval = UpdateChannel(newval, oldval, channel);
                    dst[ti] = newval;

                    li += w;
                    ri += w;
                    ti += w;
                }

                for (var j = h - r; j < h; j++)
                {
                    val += lv - (half3)src[li];

                    var newval = (RGB48)(half3)math.round(val * iarr);
                    var oldval = dst[ti];
                    newval = UpdateChannel(newval, oldval, channel);
                    dst[ti] = newval;

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

        #region IJob Members

        void IJob.Execute()
        {
            BoxesForGauss(sigma, boxes);
            BoxBlur(copy,    results, (int)((boxes[0] - 1f) / 2f), chan);
            BoxBlur(results, copy,    (int)((boxes[1] - 1f) / 2f), chan);
            BoxBlur(copy,    results, (int)((boxes[2] - 1f) / 2f), chan);
        }

        #endregion
    }
}
