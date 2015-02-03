using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    [DataContract]
    public class ResponseTapDto
    {
        [DataMember]
        public Guid ResponseTapTrnGuid { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string ReferrerUrl { get; set; }
    }
}
