using System.Collections.Generic;
using Dapper.SimpleSave.Impl;

namespace Dapper.SimpleSave
{
    public class Difference
    {
        public Difference()
        {
            Path = new List<Ancestor>();
        }

        public object OldOwner { get; set; }
        public object NewOwner { get; set; }
        public object Owner { get { return OldOwner ?? NewOwner; } }
        public DtoMetadata OwnerMetadata { get; set; }
        public PropertyMetadata OwnerPropertyMetadata { get; set; }
        public DifferenceType DifferenceType { get; set; }
        public DtoMetadata ValueMetadata { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public IList<Ancestor> Path { get; set; }
    }
}
