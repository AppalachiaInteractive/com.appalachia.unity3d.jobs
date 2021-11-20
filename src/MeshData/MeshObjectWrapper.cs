#region

using System;
using Appalachia.Core.Scriptables;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.MeshData
{
    [Serializable]
    public class MeshObjectWrapper : AppalachiaObject
    {
        [SerializeField] private Mesh _mesh;
        [NonSerialized] public MeshObject data;

        public MeshObjectWrapper()
        {
            MeshObjectManager.RegisterDisposalDependency(() => data.SafeDispose());
        }

        public Mesh mesh
        {
            get => _mesh;
            set
            {
                _mesh = value;
#if UNITY_EDITOR
                SetDirty();
#endif
            }
        }

        public bool isCreated => data.isCreated;

        public MeshObject CreateAndGetData(bool solidify)
        {
            data = new MeshObject(mesh, solidify);

#if UNITY_EDITOR
            SetDirty();
#endif

            return data;
        }
    }
}
