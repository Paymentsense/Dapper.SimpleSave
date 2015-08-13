using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl
{
    public static class ReverseUpdateHelper
    {
        public static bool IsReverseUpdateWithChildReferencingParent(UpdateOperation update)
        {
            var ownerPropMeta = update.OwnerPropertyMetadata;
            if (null == ownerPropMeta)
            {
                return false;
            }

            if (!ownerPropMeta.HasAttribute<OneToManyAttribute>()
                && !ownerPropMeta.HasAttribute<OneToOneAttribute>())
            {
                return false;
            }

            var valueMeta = update.ValueMetadata;
            if (valueMeta.IsReferenceData
                && valueMeta.HasUpdateableForeignKeys)
            {
                return true;
            }

            return ownerPropMeta.HasAttribute<ReferenceDataAttribute>()
                && ownerPropMeta.GetAttribute<ReferenceDataAttribute>().HasUpdateableForeignKeys;
        }
    }
}
