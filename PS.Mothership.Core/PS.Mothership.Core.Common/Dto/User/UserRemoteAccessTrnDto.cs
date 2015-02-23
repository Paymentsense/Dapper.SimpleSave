using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;



namespace PS.Mothership.Core.Common.Dto.User
{
    [DataContract]
    public class UserRemoteAccessTrnDto
    {
        [DataMember]
        public Guid RemoteAccessGuid { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public string ValidationCode { get; set; }

        [DataMember]
        public DateTimeOffset ExpiryOn { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }
       
    }
}
