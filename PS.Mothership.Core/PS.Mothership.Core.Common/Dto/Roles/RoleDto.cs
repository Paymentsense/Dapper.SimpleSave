using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    [KnownType(typeof(InheritedRolesDto))]
    [KnownType(typeof(UserAssignedAndAvailableRoleDto))]
    public class RoleDto
    {
        public RoleDto() { }
        public RoleDto(RoleDto role)
        {
            RoleGuid = role.RoleGuid;
            RoleName = role.RoleName;
            RoleDescription = role.RoleDescription;
            IsDefining = role.IsDefining;
            RoleStatus = role.RoleStatus;
            RoleStatusName = role.RoleStatusName;
        }
        [DataMember]
        public Guid RoleGuid { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleDescription { get; set; }
        [DataMember]
        public bool IsDefining { get; set; }
        [DataMember]
        public int RoleStatus { get; set; }
        [DataMember]
        public string RoleStatusName { get; set; }
        [DataMember]
        public int TotalCount { get; set; } 
    }
}
