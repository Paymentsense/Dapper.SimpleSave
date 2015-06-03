using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Session
{
    [DataContract]
    public class SessionHeaderDto
    {
        [DataMember]
        public Guid WebSessionGuid { get; set; }

        [DataMember]
        public Guid CorrelationGuid { get; set; }
    }
}