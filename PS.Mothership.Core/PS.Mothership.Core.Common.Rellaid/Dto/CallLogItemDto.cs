using PS.Mothership.Core.Common.Rellaid.Enums;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class CallLogItemDto
    {
        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public DateTimeOffset CallStartTime { get; set; }

        [DataMember]
        public LogCallType CallType { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
