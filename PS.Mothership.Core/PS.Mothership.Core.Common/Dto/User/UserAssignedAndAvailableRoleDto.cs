using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;

namespace PS.Mothership.Core.Common.Dto.User
{
    [DataContract]
    public class UserAssignedAndAvailableRoleDto : RoleDto
    {
        public UserAssignedAndAvailableRoleDto() { }
        public UserAssignedAndAvailableRoleDto(RoleDto role)
            : base(role)
        {

        }
        [DataMember]
        public bool AssignedToUser { get; set; }
    }
}
