using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{    
    [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public long RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public bool IsDefining { get; set; }
    }
}