#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Attributes;
using Appalachia.Core.Collections.Interfaces;
using Appalachia.Core.Collections.Native;
using Appalachia.Core.Objects.Root;
using Appalachia.Jobs.MeshData.Collections;
using Appalachia.Utility.Async;
using Appalachia.Utility.Extensions;
using Appalachia.Utility.Strings;
using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.MeshData
{
    [CallStaticConstructorInEditor]
    public class MeshObjectManager : SingletonAppalachiaBehaviour<MeshObjectManager>
    {
        static MeshObjectManager()
        {
            RegisterDependency<MeshObjectManagerMeshCollection>(i => _meshObjectManagerMeshCollection = i);
        }

        #region Static Fields and Autoproperties

        private static MeshObjectManagerMeshCollection _meshObjectManagerMeshCollection;

        #endregion

        #region Fields and Autoproperties

        private Dictionary<int, Mesh> _previousLookups = new();

        #endregion

        //public static MeshObject GetByMesh(Mesh mesh)
        public MeshObjectWrapper GetByMesh(Mesh mesh, bool solidified)
        {
            using (_PRF_GetByMesh.Auto())
            {
                try
                {
                    var hashCode = mesh.GetHashCode();

                    MeshObjectWrapper wrapper;
                    IAppaLookupSafeUpdates<int, MeshObjectWrapper, MeshObjectWrapperList> collection;

                    using (_PRF_GetByMesh_CheckCollection.Auto())
                    {
                        collection =
                            (solidified
                                ? _meshObjectManagerMeshCollection.SoldifiedMeshes
                                : _meshObjectManagerMeshCollection.Meshes).Items;

                        if (collection.ContainsKey(hashCode))
                        {
                            wrapper = collection.Get(hashCode);

                            if (wrapper.data.isCreated && !wrapper.data.vertices.ShouldAllocate())
                            {
                                return wrapper;
                            }
                        }
                    }

#if UNITY_EDITOR
                    using (_PRF_GetByMesh_CreateWrapper.Auto())
                    {
                        var uniqueName = ZString.Format(
                            "{0}_{1}v_{2}t",
                            mesh.name,
                            mesh.vertexCount,
                            mesh.triangles.Length
                        );
                        wrapper = MeshObjectWrapper.LoadOrCreateNew(uniqueName);

                        wrapper.data = new MeshObject(mesh, solidified);
                        wrapper.mesh = mesh;
                        Modifications.MarkAsModified(wrapper);
                    }

                    using (_PRF_GetByMesh_UpdateCollection.Auto())
                    {
                        collection.AddOrUpdate(hashCode, wrapper);
                    }
#else
                    wrapper = null;
#endif

                    return wrapper;
                }
                catch (Exception ex)
                {
                    Context.Log.Error(ZString.Format("Failed to get mesh object: {0}", ex));
                    return default;
                }
            }
        }

        public Mesh GetCheapestMesh(GameObject obj)
        {
            using (_PRF_GetCheapestMesh.Auto())
            {
                if (_previousLookups == null)
                {
                    _previousLookups = new Dictionary<int, Mesh>();
                }

                var objHashCode = obj.GetHashCode();

                if (_previousLookups.ContainsKey(objHashCode))
                {
                    var prev = _previousLookups[objHashCode];
                    return prev;
                }

                MeshFilter meshFilter = null;

                var minimumVertexCount = 24;

                var lodGroup = obj.GetComponentInChildren<LODGroup>();

                if (lodGroup == null)
                {
                    var filters = obj.GetComponentsInChildren<MeshFilter>();

                    if (filters.Length == 0)
                    {
                        throw new NotSupportedException(ZString.Format("Missing mesh for {0}", obj.name));
                    }

                    var sortedFilters = filters.OrderBy(mf => mf.sharedMesh.vertexCount).ToArray();

                    meshFilter = sortedFilters.FirstOrDefault(
                        mf => (mf.sharedMesh.vertexCount > minimumVertexCount) &&
                              !mf.sharedMesh.name.EndsWith("_GIZMO")
                    );

                    if (meshFilter == null)
                    {
                        meshFilter = sortedFilters.FirstOrDefault();
                    }
                }
                else
                {
                    var lods = lodGroup.GetLODs();

                    for (var i = lods.Length - 1; i >= 0; i--)
                    {
                        var lod = lods[i];

                        if (lod.renderers.Length > 0)
                        {
                            var renderer = lod.renderers[0];

                            meshFilter = renderer.GetComponent<MeshFilter>();

                            if (meshFilter.sharedMesh.vertexCount > minimumVertexCount)
                            {
                                break;
                            }
                        }
                    }

                    if (meshFilter == null)
                    {
                        throw new NotSupportedException(ZString.Format("Missing mesh for {0}", obj.name));
                    }
                }

                var resultingMesh = meshFilter.sharedMesh;

                _previousLookups.Add(objHashCode, resultingMesh);

                return resultingMesh;
            }
        }

        public MeshObjectWrapper GetCheapestMeshWrapper(GameObject obj, bool solidified)
        {
            using (_PRF_GetCheapestMeshWrapper.Auto())
            {
                var mesh = GetCheapestMesh(obj);

                return GetByMesh(mesh, solidified);
            }
        }

        /// <inheritdoc />
        protected override async AppaTask WhenDisabled()
        {
            await base.WhenDisabled();
            using (_PRF_WhenDisabled.Auto())
            {
                DisposeNativeCollections();
            }
        }

        private void DisposeNativeCollections()
        {
            using (_PRF_DisposeNativeCollections.Auto())
            {
                if (_meshObjectManagerMeshCollection == null)
                {
                    return;
                }

                _meshObjectManagerMeshCollection.Dispose();
            }
        }

        #region Profiling

        private static readonly ProfilerMarker _PRF_DisposeNativeCollections =
            new(_PRF_PFX + nameof(DisposeNativeCollections));

        private static readonly ProfilerMarker _PRF_GetByMesh = new(_PRF_PFX + nameof(GetByMesh));

        private static readonly ProfilerMarker _PRF_GetByMesh_CheckCollection =
            new(_PRF_PFX + nameof(GetByMesh) + ".CheckCollection");

        private static readonly ProfilerMarker _PRF_GetByMesh_CreateWrapper =
            new(_PRF_PFX + nameof(GetByMesh) + ".CreateWrapper");

        private static readonly ProfilerMarker _PRF_GetByMesh_Initialize =
            new(_PRF_PFX + nameof(GetByMesh) + ".Initialize");

        private static readonly ProfilerMarker _PRF_GetByMesh_UpdateCollection =
            new(_PRF_PFX + nameof(GetByMesh) + ".UpdateCollection");

        private static readonly ProfilerMarker _PRF_GetCheapestMesh = new(_PRF_PFX + nameof(GetCheapestMesh));

        private static readonly ProfilerMarker _PRF_GetCheapestMeshWrapper =
            new(_PRF_PFX + nameof(GetCheapestMeshWrapper));

        #endregion
    }
}
