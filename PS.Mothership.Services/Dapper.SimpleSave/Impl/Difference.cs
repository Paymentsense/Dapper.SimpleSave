namespace Dapper.SimpleSave.Impl
{
    public class Difference
    {
        public object OldOwner { get; set; }
        public object NewOwner { get; set; }
        public object Owner { get { return OldOwner ?? NewOwner; } }
        public DtoMetadata OwnerMetadata { get; set; }
        public int? OwnerId
        {
            get
            {
                var owner = Owner;
                return null == owner
                    ? null
                    : (null == OwnerMetadata ? null : (int?)OwnerMetadata.GetPrimaryKeyValue(owner));
            }
        }
        public PropertyMetadata OwnerPropertyMetadata { get; set; }
        public DifferenceType DifferenceType { get; set; }
        public DtoMetadata ValueMetadata { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
