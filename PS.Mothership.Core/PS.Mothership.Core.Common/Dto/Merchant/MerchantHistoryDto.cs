using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class MerchantHistoryDto
    {
        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public DateTimeOffset? LastAccessTime { get; set; }
    }
}
