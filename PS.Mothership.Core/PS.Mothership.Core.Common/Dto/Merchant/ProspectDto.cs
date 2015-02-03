using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ProspectDto : MerchantDto
    {
        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public string DeDupeBusinessName { get; set; }

        [DataMember]
        public bool? DoesEcommerce { get; set; }

        [DataMember]
        public short? DelphiScore { get; set; }
    }
}
