using System;
using System.Collections.Generic;
using System.Linq;
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

        public int? OwnerPrimaryKey
        {
            get
            {
                return null == Owner
                    ? null
                    : (null == OwnerMetadata ? null : OwnerMetadata.GetPrimaryKeyValue(Owner));
            }
        }

        public DtoMetadata ValueMetadata { get; set; }

        public object Value { get; set; }
    }
}
