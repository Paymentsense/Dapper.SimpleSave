using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

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
            Name = role.Name;
            Description = role.Description;
            IsDefining = role.IsDefining;
            RoleStatus = role.RoleStatus;
        }
        [DataMember]
        public Guid RoleGuid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsDefining { get; set; }
        [DataMember]
        public GenRecStatusEnum RoleStatus { get; set; }
    }
}
