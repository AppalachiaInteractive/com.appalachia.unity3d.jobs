using System;
using Appalachia.Core.Collections.Implementations.Lists;
using Appalachia.Core.Objects.Scriptables;
using Appalachia.Jobs.MeshData.Collections;

namespace Appalachia.Jobs.MeshData
{
    [Serializable]
    public class MeshObjectWrapperLookupCollection : AppalachiaObjectLookupCollection<int, MeshObjectWrapper,
        intList, MeshObjectWrapperList, MeshObjectWrapperLookup, MeshObjectWrapperLookupCollection>
    {
        /// <inheritdoc />
        public override bool HasDefault => false;

        /// <inheritdoc />
        protected override int GetUniqueKeyFromValue(MeshObjectWrapper value)
        {
            return value.mesh.GetHashCode();
        }
    }
}
