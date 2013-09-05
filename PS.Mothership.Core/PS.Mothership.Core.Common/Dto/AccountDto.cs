using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Security;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class AccountDto
    {       
        [DataMember]
        public MembershipCreateStatus Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public UserProfileDto UserProfileDto { get;  set; }

        [DataMember]
        public IEnumerable<UserRoleDto> Roles { get; set; }
    }
}