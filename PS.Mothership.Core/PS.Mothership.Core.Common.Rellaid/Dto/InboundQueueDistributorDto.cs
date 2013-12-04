using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class InboundQueueDistributorDto
    {
        [DataMember]
        public string FilterNumber { get; set; }
        [DataMember]
        public int RungCount { get; set; }
    }
}
