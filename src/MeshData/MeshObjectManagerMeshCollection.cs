using Appalachia.Core.Objects.Initialization;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Async;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Jobs.MeshData
{
    public class MeshObjectManagerMeshCollection : SingletonAppalachiaObject<MeshObjectManagerMeshCollection>
    {
        #region Constants and Static Readonly

        private const string MESHES = "Meshes";
        private const string SOLIDIFIED_MESHES = "SoldifiedMeshes";

        #endregion

        #region Fields and Autoproperties

        [SerializeField] private MeshObjectWrapperLookupCollection _meshes;
        [SerializeField] private MeshObjectWrapperLookupCollection _soldifiedMeshes;

        #endregion

        public MeshObjectWrapperLookupCollection Meshes => _meshes;

        public MeshObjectWrapperLookupCollection SoldifiedMeshes => _soldifiedMeshes;

        public void Dispose()
        {
            using (_PRF_Dispose.Auto())
            {
                for (var i = 0; i < _meshes.Count; i++)
                {
                    var mesh = _meshes.Items.GetByIndex(i);
                    mesh.data.Dispose();
                }

                for (var i = 0; i < _soldifiedMeshes.Count; i++)
                {
                    var mesh = _soldifiedMeshes.Items.GetByIndex(i);
                    mesh.data.Dispose();
                }
            }
        }

        protected override async AppaTask Initialize(Initializer initializer)
        {
            await base.Initialize(initializer);

#if UNITY_EDITOR
            initializer.Do(
                this,
                MESHES,
                _meshes == null,
                () =>
                {
                    using (_PRF_Initialize.Auto())
                    {
                        _meshes = MeshObjectWrapperLookupCollection.LoadOrCreateNew(MESHES);
                    }
                }
            );

            initializer.Do(
                this,
                SOLIDIFIED_MESHES,
                _soldifiedMeshes == null,
                () =>
                {
                    using (_PRF_Initialize.Auto())
                    {
                        _soldifiedMeshes =
                            MeshObjectWrapperLookupCollection.LoadOrCreateNew(SOLIDIFIED_MESHES);
                    }
                }
            );
#endif
        }

        #region Profiling

        private static readonly ProfilerMarker _PRF_Dispose = new ProfilerMarker(_PRF_PFX + nameof(Dispose));

        #endregion
    }
}
