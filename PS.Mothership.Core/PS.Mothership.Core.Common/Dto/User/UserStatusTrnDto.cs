using PS.Mothership.Core.Common.Template.Usr;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.User
{
    [DataContract]
    public class UserStatusTrnDto
    {
        [DataMember]
        public Guid UserStatusTrnGuid { get; set; }
        public Guid UserGuid { get; set; }
        public UsrUserStatusEnum UserStatusKey { get; set; }
        public Guid UpdateSessionGuid { get; set; }
    }
}
