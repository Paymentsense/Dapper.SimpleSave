using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Security;
using PS.Mothership.Core.Common.Template.PsMsContext;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class AccountDto
    {       
        [DataMember]
        public LoginUserResultStatusLutEnum Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public UserProfileDto UserProfileDto { get;  set; }

        [DataMember]
        public IEnumerable<UserRoleDto> Roles { get; set; }
    }
}