#region

using System;
using Appalachia.Core.Collections;
using Appalachia.Core.Collections.Implementations.Lists;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Appalachia.Jobs.MeshData.Collections
{
    [Serializable]
    [ListDrawerSettings(
        Expanded = true,
        DraggableItems = false,
        HideAddButton = true,
        HideRemoveButton = true,
        NumberOfItemsPerPage = 5
    )]
    public class MeshObjectWrapperLookup : AppaLookup<int, MeshObjectWrapper, intList, MeshObjectWrapperList>
    {
        /// <inheritdoc />
        protected override Color GetDisplayColor(int key, MeshObjectWrapper value)
        {
            return Color.white;
        }

        /// <inheritdoc />
        protected override string GetDisplaySubtitle(int key, MeshObjectWrapper value)
        {
            return string.Empty;
        }

        /// <inheritdoc />
        protected override string GetDisplayTitle(int key, MeshObjectWrapper value)
        {
            return value.mesh.name;
        }
    }
}
