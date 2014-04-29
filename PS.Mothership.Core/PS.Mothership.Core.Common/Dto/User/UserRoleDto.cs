using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.User
{    
    [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public Guid RoleGuid { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public bool IsDefining { get; set; }
    }
}