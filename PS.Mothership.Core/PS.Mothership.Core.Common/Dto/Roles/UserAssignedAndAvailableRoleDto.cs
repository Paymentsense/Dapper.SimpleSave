using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
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
