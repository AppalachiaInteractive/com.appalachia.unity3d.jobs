#region

using System;
using Appalachia.Core.Attributes;
using Appalachia.Core.Objects.Initialization;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Async;
using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.MeshData
{
    [Serializable]
    [CallStaticConstructorInEditor]
    public class MeshObjectWrapper : AppalachiaObject<MeshObjectWrapper>
    {
        static MeshObjectWrapper()
        {
            MeshObjectManager.InstanceAvailable += i => _meshObjectManager = i;
        }

        #region Static Fields and Autoproperties

        private static MeshObjectManager _meshObjectManager;

        #endregion

        #region Fields and Autoproperties

        [SerializeField] private Mesh _mesh;
        [NonSerialized] public MeshObject data;

        #endregion

        public bool isCreated => data.isCreated;

        public Mesh mesh
        {
            get => _mesh;
            set
            {
                _mesh = value;
#if UNITY_EDITOR
                MarkAsModified();
#endif
            }
        }

        public MeshObject CreateAndGetData(bool solidify)
        {
            data = new MeshObject(mesh, solidify);

#if UNITY_EDITOR
            MarkAsModified();
#endif

            return data;
        }

        protected override async AppaTask Initialize(Initializer initializer)
        {
            using (_PRF_Initialize.Auto())
            {
                await base.Initialize(initializer);

                _meshObjectManager.RegisterDisposalDependency(() => data.SafeDispose());
            }
        }

        #region Profiling

        private const string _PRF_PFX = nameof(MeshObjectWrapper) + ".";

        private static readonly ProfilerMarker _PRF_Initialize =
            new ProfilerMarker(_PRF_PFX + nameof(Initialize));

        #endregion
    }
}
