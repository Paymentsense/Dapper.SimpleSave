using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserAssignedAndAvailableRole : Role
    {
        public UserAssignedAndAvailableRole()
        {
        }

        public UserAssignedAndAvailableRole(Role role)
            : base(role)
        {

        }

        [DataMember]
        public bool AssignedToUser { get; set; }
    }
}
