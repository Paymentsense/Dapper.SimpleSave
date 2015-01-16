using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class MerchantCategoryCodeDto
    {
        [DataMember]
        public int MccKey { get; set; }

        [DataMember]
        public int MCCCategoryKey { get; set; }

        [DataMember]
        public string Mcc { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Category { get; set; }
    }
}
