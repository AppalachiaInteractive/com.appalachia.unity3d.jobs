#region

using System;
using Appalachia.Core.Objects.Initialization;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Async;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.MeshData
{
    [Serializable]
    public class MeshObjectWrapper : AppalachiaObject<MeshObjectWrapper>
    {
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
                MeshObjectManager.instance.RegisterDisposalDependency(() => data.SafeDispose());
            }
        }

        #region Profiling

        private const string _PRF_PFX = nameof(MeshObjectWrapper) + ".";

        #endregion
    }
}
