using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class InboundQueueCallRecordDto
    {
        [DataMember]
        public long? CampaignId { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string ReferrerUrl { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
    }
}
