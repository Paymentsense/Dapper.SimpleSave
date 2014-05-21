using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class InboundQueueDistributorDto
    {
        [DataMember]
        public string FilterNumber { get; set; }

        [DataMember]
        public int RungCount { get; set; }

        [DataMember]
        public bool CanReceiveCalls { get; set; }
    }
}
