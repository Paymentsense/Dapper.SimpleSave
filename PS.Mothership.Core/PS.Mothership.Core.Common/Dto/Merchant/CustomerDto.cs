using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class CustomerDto : MerchantDto
    {
        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public string DeDupeBusinessName { get; set; }

        [DataMember]
        public bool IsVatExempt { get; set; }
      
    }
}
