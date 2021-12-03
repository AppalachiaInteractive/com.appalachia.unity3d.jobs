using Appalachia.Jobs.TextureJobs.Structures;
using Unity.Collections;
using Unity.Mathematics;

namespace Appalachia.Jobs.TextureJobs.Jobs.EdgeDetect
{
    [Unity.Burst.BurstCompile]
    public struct EdgeDetectRGB24Job : Unity.Jobs.IJobParallelFor
    {
        public EdgeDetectRGB24Job(NativeArray<RGB24> data, int texture_width)
        {
            results = data;
            copy = new NativeArray<RGB24>(data, Allocator.TempJob);
            Last = results.Length - 1;
            Width = texture_width;
        }

        #region Fields and Autoproperties

        private readonly int Last;
        private readonly int Width;

        [DeallocateOnJobCompletion]
        [NativeDisableParallelForRestriction]
        private NativeArray<RGB24> copy;

        private NativeArray<RGB24> results;

        #endregion

        #region IJobParallelFor Members

        void Unity.Jobs.IJobParallelFor.Execute(int i)
        {
            var px = copy[i];
            var pr = copy[math.min(i + 1,     Last)];
            var pb = copy[math.min(i + Width, Last)];

            var f = (byte)math.max(
                math.abs((px.R + px.G + px.B) - (pr.R + pr.G + pr.B)),
                math.abs((px.R + px.G + px.B) - (pb.R + pb.G + pb.B))
            );

            results[i] = new RGB24 { R = f, G = f, B = f };
        }

        #endregion
    }
}
