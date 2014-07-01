using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Dto.User;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.Login
{
    [DataContract]
    public class LoginTrnDto
    {
        [DataMember]
        public Guid LoginGuid { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ClientIP { get; set; }
        [DataMember]
        public long? IPKey { get; set; }
        [DataMember]
        public int PasswordFailureCount { get; set; }
        [DataMember]
        public UsrLoginResultEnum LoginResultKey { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
    }
}