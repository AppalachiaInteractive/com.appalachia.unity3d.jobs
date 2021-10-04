#region

using System;
using Appalachia.Core.Collections.Native;
using Appalachia.Jobs.Optimization.Metadata;
using Appalachia.Jobs.Optimization.Parameters;
using Appalachia.Jobs.Optimization.Utilities;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;

#endregion

namespace Appalachia.Jobs.Optimization
{
    public static class Optimizer
    {
        private const string _PRF_PFX = nameof(Optimizer) + ".";

        private static readonly ProfilerMarker _PRF_ScheduleOptimizationJobs =
            new(_PRF_PFX + nameof(ScheduleOptimizationJobs));

        private static readonly ProfilerMarker _PRF_ScheduleOptimizationJobs_Parameters =
            new(_PRF_PFX + nameof(ScheduleOptimizationJobs) + ".Parameters");

        private static readonly ProfilerMarker _PRF_ScheduleOptimizationJobs_JobDelegate =
            new(_PRF_PFX + nameof(ScheduleOptimizationJobs) + ".JobDelegate");

        public static JobHandle ScheduleOptimizationJobs(
            NativeArray<ParameterSpecification> paramSpecs,
            NativeArray3D<double> parameterSets,
            NativeArray2D<OptimizationResult> results,
            NativeArray<OptimizationResult> bestResults,
            JobRandoms randoms,
            JobHandle inputHandle,
            Func<JobHandle, NativeArray3D<double>, NativeArray2D<OptimizationResult>, JobHandle>
                optimizationJobCreator)
        {
            using (_PRF_ScheduleOptimizationJobs.Auto())
            {
                using (_PRF_ScheduleOptimizationJobs_Parameters.Auto())
                {
                    var instanceCount = results.Length0;

                    inputHandle = new RandomSearch_ParametersWideJob
                    {
                        parameterSets = parameterSets,
                        parameterSpecifications = paramSpecs,
                        randoms = randoms
                    }.Schedule3D(parameterSets, 64, inputHandle);

                    using (_PRF_ScheduleOptimizationJobs_JobDelegate.Auto())
                    {
                        inputHandle = optimizationJobCreator(inputHandle, parameterSets, results);
                    }

                    inputHandle =
                        new ChooseBestResultWideJob {results = results, bestResults = bestResults}
                           .Schedule(instanceCount, 16, inputHandle);
                }

                return inputHandle;
            }
        }

        /*public static JobHandle ScheduleOptimizationJobs(
            int instanceCount,
            int iterationCount,
            NativeArray<ParameterSpecification> paramSpecs,
            NativeArray2D<double> parameterSets,
            NativeArray2D<OptimizationResult> results,
            NativeArray<OptimizationResult> bestResults,
            JobRandoms randoms,
            NativeList<JobHandle> dependencyList,
            JobHandle inputHandle,
            Func<JobHandle, int, NativeArray<double>, NativeArray<OptimizationResult>, JobHandle> optimizationJobCreator)
        {
            TraceMarker.LogMethod(TraceType.ENTRY);

            using (PROFILING.OPTIMIZE.ScheduleOptimizationJobs.Auto())
            {
                dependencyList.Clear();

                using (PROFILING.OPTIMIZE.ScheduleParamJobs.Auto())
                {
                    for (var instanceIndex = 0; instanceIndex < instanceCount; instanceIndex++)
                    {
                        var parameterSetsLocal = parameterSets[instanceIndex];

                        var parameterHandle = new RandomSearch_ParametersJob()
                        {
                            parameterSets = parameterSetsLocal, parameterSpecifications = paramSpecs, randoms = randoms,
                        }.Schedule(iterationCount, 128, inputHandle);

                        var result = results[instanceIndex];

                        JobHandle implementationHandle;

                        using (PROFILING.OPTIMIZE.CallDelegateCreator.Auto())
                        {
                            implementationHandle = optimizationJobCreator(parameterHandle, instanceIndex, parameterSetsLocal, result.allResults);
                        }

                        var resultHandle = new ChooseBestResultJob()
                        {
                            allResults = result.allResults.AsDeferredJobArray(), bestResult = result.bestResultArray, limit = iterationCount
                        }.Schedule(implementationHandle);

                        dependencyList.Add(resultHandle);
                    }
                }

                JobHandle combinedHandle;

               
using(ASPECT.Many(ASPECT.Profile(), ASPECT.Trace()))
                {
                    combinedHandle = JobHandle.CombineDependencies(dependencyList);

                    dependencyList.Clear();
                }

                return combinedHandle;
            }
        }
        */

        [BurstCompile]
        private struct RandomSearch_ParametersWideJob : IJobParallelFor3D
        {
            [ReadOnly] public JobRandoms randoms;
            [ReadOnly] public NativeArray<ParameterSpecification> parameterSpecifications;

            public NativeArray3D<double> parameterSets;

            public void Execute(int flatIndex)
            {
                parameterSets.ReverseIndex(flatIndex, out var x, out var y, out var z);

                var specification = parameterSpecifications[z];

                var random = randoms.Get(flatIndex);

                var parameterValue = specification.SampleValue(random);

                parameterSets[x, y, z] = parameterValue;
            }
        }

        [BurstCompile]
        private struct ChooseBestResultWideJob : IJobParallelFor
        {
            [ReadOnly] public NativeArray2D<OptimizationResult> results;
            [WriteOnly] public NativeArray<OptimizationResult> bestResults;

            public void Execute(int index0)
            {
                var best = results[index0, 0];

                for (var index1 = 1; index1 < results.Length1; index1++)
                {
                    var result = results[index0, index1];

                    if (result.error < best.error)
                    {
                        best = result;
                    }
                }

                bestResults[index0] = best;
            }
        }

        /*[BurstCompile]
        private struct RandomSearch_ParametersJob : IJobParallelFor
        {
            [ReadOnly] public NativeArray<ParameterSpecification> parameterSpecifications;
            [ReadOnly] public JobRandoms randoms;

            [WriteOnly, NativeDisableParallelForRestriction]
            public NativeArray<double> parameterSets;

            public void Execute(int index)
            {
                var startIndex = index * parameterSpecifications.Length;

                for (var j = 0; j < parameterSpecifications.Length; j++)
                {
                    var specification = parameterSpecifications[j];
                    var random = randoms.Get(startIndex + j);

                    var parameterValue = specification.SampleValue(random);

                    parameterSets[startIndex + j] = parameterValue;
                }
            }
        }

        [BurstCompile]
        private struct ChooseBestResultJob : IJob
        {
            [ReadOnly] public NativeArray<OptimizationResult> allResults;
            [WriteOnly] public NativeArray<OptimizationResult> bestResult;
            [ReadOnly] public int limit;

            public void Execute()
            {
                OptimizationResult best = allResults[0];

                for (var i = 1; i < limit; i++)
                {
                    var result = allResults[i];

                    if (result.error < best.error)
                    {
                        best = result;
                    }
                }

                bestResult[0] = best;
            }
        }*/
    }
}
