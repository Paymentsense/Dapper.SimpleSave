using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Dto.User;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.Login
{
    [DataContract]
    public class SessionDto
    {       
        [DataMember]
        public Guid SessionGuid { get; set; }
        [DataMember]
        public DateTimeOffset StartDateTime { get; set; }
        [DataMember]
        public DateTimeOffset? EndDateTime { get; set; }
       
    }
}