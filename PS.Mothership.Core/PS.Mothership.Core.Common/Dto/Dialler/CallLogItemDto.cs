using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums.Dialler;

namespace PS.Mothership.Core.Common.Dto.Dialler
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
