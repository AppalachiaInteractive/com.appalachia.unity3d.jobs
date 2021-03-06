using System;
using System.Collections.Generic;
using Appalachia.Core.Collections.Native;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Jobs.Transformations
{
    public static class LocalToWorldJob
    {
        [NonSerialized] private static readonly Dictionary<int, TransformLocalToWorld> Data = new();

        public static void SetupJob(
            int guid,
            NativeArray<float3> positions,
            ref NativeArray<float3> output)
        {
            if (Data.ContainsKey(guid))
            {
                Data[guid] = new TransformLocalToWorld
                {
                    PositionsWorld = output, PositionsLocal = positions
                };
            }
            else
            {
                var jobData = new TransformLocalToWorld
                {
                    PositionsWorld = output, PositionsLocal = positions
                };

                Data.Add(guid, jobData);
            }
        }

        public static void SetupJob(int guid, Vector3[] positions, ref NativeArray<float3> output)
        {
            var array = new NativeArray<float3>(positions.Length, Allocator.Persistent);

            for (var i = 0; i < positions.Length; i++)
            {
                array[i] = positions[i];
            }

            SetupJob(guid, array, ref output);
        }

        public static JobHandle ScheduleJob(int guid, Matrix4x4 localToWorld)
        {
            if (!Data.ContainsKey(guid))
            {
                return default;
            }

            if (Data[guid].Processing)
            {
                return default;
            }

            Data[guid].Job = new LocalToWorldConvertJob
            {
                PositionsWorld = Data[guid].PositionsWorld,
                PositionsLocal = Data[guid].PositionsLocal,
                Matrix = localToWorld
            };

            var handle = Data[guid].Job.Schedule();
            Data[guid].Handle = handle;
            Data[guid].Processing = true;
            JobHandle.ScheduleBatchedJobs();

            return handle;
        }

        public static void CompleteJob(int guid)
        {
            if (!Data.ContainsKey(guid))
            {
                return;
            }

            Data[guid].Handle.Complete();
            Data[guid].Processing = false;
        }

        public static void Cleanup(int guid)
        {
            if (!Data.ContainsKey(guid))
            {
                return;
            }

            Data[guid].Handle.Complete();
            Data[guid].PositionsWorld.SafeDispose();
            Data[guid].PositionsLocal.SafeDispose();
            Data.Remove(guid);
        }

        [BurstCompile]
        public struct LocalToWorldConvertJob : IJob
        {
            [WriteOnly] public NativeArray<float3> PositionsWorld;

            [ReadOnly] public Matrix4x4 Matrix;

            [ReadOnly] public NativeArray<float3> PositionsLocal;

            // The code actually running on the job
            public void Execute()
            {
                for (var i = 0; i < PositionsLocal.Length; i++)
                {
                    var pos = float4.zero;
                    pos.xyz = PositionsLocal[i];
                    pos.w = 1f;
                    pos = Matrix * pos;
                    PositionsWorld[i] = pos.xyz;
                }
            }
        }

        private class TransformLocalToWorld
        {
            public JobHandle Handle;
            public LocalToWorldConvertJob Job;
            public NativeArray<float3> PositionsLocal;
            public NativeArray<float3> PositionsWorld;
            public bool Processing;
        }
    }
}
