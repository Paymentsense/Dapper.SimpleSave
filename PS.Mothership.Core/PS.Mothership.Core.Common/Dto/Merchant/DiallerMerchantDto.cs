using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class DiallerMerchantDto
    {
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string PrimaryContactName { get; set; }
        [DataMember]
        public DateTimeOffset? UpdateDate { get; set; }
        [DataMember]
        public Guid MerchantGuid { get; set; }
        [DataMember]
        public string StreetAddress { get; set; }
        [DataMember]
        public string BusinessName { get; set; }
        [DataMember]
        public bool IsCustomer { get; set; }
        [DataMember]
        public Guid OwnershipUserGuid { get; set; }
    }
}
