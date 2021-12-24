#region

using System;
using Appalachia.Core.Collections;

#endregion

namespace Appalachia.Jobs.MeshData.Collections
{
    [Serializable]
    public sealed class MeshObjectWrapperList : AppaList<MeshObjectWrapper>
    {
        public MeshObjectWrapperList()
        {
        }

        public MeshObjectWrapperList(
            int capacity,
            float capacityIncreaseMultiplier = 2,
            bool noTracking = false) : base(capacity, capacityIncreaseMultiplier, noTracking)
        {
        }

        public MeshObjectWrapperList(AppaList<MeshObjectWrapper> list) : base(list)
        {
        }

        public MeshObjectWrapperList(MeshObjectWrapper[] values) : base(values)
        {
        }
    }
}
