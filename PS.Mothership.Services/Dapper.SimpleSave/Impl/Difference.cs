using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class Difference {

        public object OldOwner { get; set; }
        public object NewOwner { get; set; }

        public object Owner
        {
            get { return OldOwner ?? NewOwner; }
        }

        //public object OldParentObject { get; set; }
        //public object NewParentObject { get; set; }
        public DtoMetadata OwnerMetadata { get; set; }

        public int? OwnerId
        {
            get
            {
                var owner = Owner;
                return null == owner
                    ? null
                    : (null == OwnerMetadata ? null : OwnerMetadata.GetPrimaryKeyValue(owner));
            }
        }

        public PropertyMetadata OwnerPropertyMetadata { get; set; }

        public DifferenceType DifferenceType { get; set; }

        public DtoMetadata ValueMetadata { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
