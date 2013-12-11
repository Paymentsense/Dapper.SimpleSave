using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class CallStatsDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public TimeSpan TotalTalkTime { get; set; }
        [DataMember]
        public TimeSpan TotalWrapTime { get; set; }
    }
}
