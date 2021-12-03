
using Unity.Collections;

namespace Appalachia.Jobs.TextureJobs.Jobs.Invert
{
	[Unity.Burst.BurstCompile]
	public struct InvertByteJob : Unity.Jobs.IJobParallelFor
	{
		public NativeArray<byte> data;
		void Unity.Jobs.IJobParallelFor.Execute ( int i ) => data[i] = (byte)( byte.MaxValue - data[i] );
	}
}
