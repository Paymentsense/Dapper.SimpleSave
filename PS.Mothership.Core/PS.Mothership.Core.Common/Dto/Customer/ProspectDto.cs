using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    [DataContract]
    public class ProspectDto : MerchantDto
    {
        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public string DeDupeBusinessName { get; set; }

        [DataMember]
        public bool DoesEcommerce { get; set; }

        [DataMember]
        public int DelphiScore { get; set; }
    }
}
