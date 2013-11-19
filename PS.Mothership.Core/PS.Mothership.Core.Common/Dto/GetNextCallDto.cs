using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class GetNextCallDto
    {
        [DataMember]
        List<CallQueueDto> CallQueues { get; set; }
        [DataMember]
        public long PcCallTranId { get; set; }
        [DataMember]
        public Guid MerchantGuid { get; set; }
        [DataMember]
        public string DialPhone { get; set; }
        [DataMember]
        public string CampaignName { get; set; }
        [DataMember]
        public long CampaignId { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string ReferrerUrl { get; set; }
    }
}
