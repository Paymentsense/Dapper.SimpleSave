using PS.Mothership.Core.Common.Template.Usr;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Login
{
    [DataContract]
    public class LoginTrnDto
    {       
        [DataMember]
        public Guid LoginGuid { get; set; }
        [DataMember]
        public string UserName { get;  set; }
        [DataMember]
        public string ClientIP { get; set; }
        [DataMember]
        public long? IPKey { get; set; }
        [DataMember]
        public int PasswordFailureCountChange { get; set; }
        [DataMember]
        public UsrLoginResultEnum LoginResultKey { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
    }
}