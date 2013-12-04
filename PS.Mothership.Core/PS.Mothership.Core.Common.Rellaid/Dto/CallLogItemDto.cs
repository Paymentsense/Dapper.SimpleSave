using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Rellaid.Enums;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class CallLogItemDto
    {
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public DateTime CallStartTime { get; set; }
        [DataMember]
        public LogCallType CallType { get; set; }
    }
}
