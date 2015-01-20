using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class SpeedDialNumberDto
    {       
        [DataMember]
        public Guid SpeedDialNumberGuid { get; set; }
        [DataMember]
        public Guid PhoneGuid { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }
        [DataMember]
        public bool Locked { get; set; }
    }
}