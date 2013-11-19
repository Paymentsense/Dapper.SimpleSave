using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class GetMerchantByPhoneDto
    {
        [DataMember]
        List<MerchantDto> Merchants { get; set; }
        [DataMember]
        public long? AdinsightCallTrnId { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string ReferringUrl { get; set; }
    }
}
