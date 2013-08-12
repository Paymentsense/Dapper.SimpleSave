using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class AccountDto
    {
        [DataMember]
        public UserProfileDto UserProfileDto { get;  set; }

        [DataMember]
        public IEnumerable<UserRoleDto> Roles { get; set; }
    }
}