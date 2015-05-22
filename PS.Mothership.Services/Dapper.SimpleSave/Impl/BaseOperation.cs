using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class BaseOperation
    {
        public DtoMetadata OwnerMetadata { get; set; }

        public PropertyMetadata OwnerPropertyMetadata { get; set; }

        public string TableName { get; set; }

        public string OwnerPrimaryKeyColumn { get; set; }

        public int? OwnerPrimaryKey { get; set; }

        public object Value { get; set; }
    }
}
