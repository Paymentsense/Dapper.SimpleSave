using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.Login
{
    [DataContract]
    public class AccountDto
    {       
        [DataMember]
        public LoginResultEnum Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public UserProfileDto UserProfileDto { get;  set; }
        [DataMember]
        public IEnumerable<UserRoleDto> Roles { get; set; }
    }
}