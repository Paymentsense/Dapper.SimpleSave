using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public abstract class BaseOperation
    {
        public object Owner { get; set; }

        public DtoMetadata OwnerMetadata { get; set; }

        public PropertyMetadata OwnerPropertyMetadata { get; set; }

        public string TableName { get; set; }

        public string OwnerPrimaryKeyColumn { get; set; }

        public object OwnerPrimaryKeyAsObject
        {
            get
            {
                return Owner == null
                    ? null
                    : (OwnerMetadata == null ? null : OwnerMetadata.GetPrimaryKeyValueAsObject(Owner));
            }
        }

        public DtoMetadata ValueMetadata { get; set; }

        public object Value { get; set; }
    }
}
