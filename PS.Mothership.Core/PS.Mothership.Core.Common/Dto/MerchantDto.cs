using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class MerchantDto
    {
        [DataMember]
        public Guid MerchantGuid { get; set; }
        [DataMember]
        public string TradingName { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public DateTime LastUpdateDate { get; set; }
        [DataMember]
        public string Address1 { get; set; }
    }
}
