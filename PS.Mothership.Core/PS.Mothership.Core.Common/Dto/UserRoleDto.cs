using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public long RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }
    }

    [DataContract]
    public class UserGroupDto
    {
        [DataMember]
        public long GroupId { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public List<UserRoleDto> Role { get; set; }
    }

    [DataContract]
    public class UserPermissionDto
    {
        [DataMember]
        public PermissionLutEnum PermissionEnums { get; set; }        

        [DataMember]
        public string PermissionName { get; set; }

        [DataMember]
        public UserRoleDto Role { get; set; }        
    }
}