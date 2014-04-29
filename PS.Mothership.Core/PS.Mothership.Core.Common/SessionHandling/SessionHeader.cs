using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.SessionHandling
{
    [DataContract]
    public class SessionHeader
    {
        [DataMember]
        public Guid WebSessionGuid { get; set; }
    }
}