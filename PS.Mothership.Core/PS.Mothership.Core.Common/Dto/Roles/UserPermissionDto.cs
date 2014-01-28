using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    [Obsolete]
    public class UserPermissionDto
    {
        [DataMember]
        public UserPermissionFlagEnum PermissionEnums { get; set; }        

        [DataMember]
        public string PermissionName { get; set; }

        [DataMember]
        public UserRoleDto Role { get; set; }        
    }
}