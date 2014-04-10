using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.User
{
    [DataContract]
    [Obsolete]
    public class UserPermissionDto
    {
        [DataMember]
        public UsrUserPermissionFlagEnum PermissionEnums { get; set; }        

        [DataMember]
        public string PermissionName { get; set; }

        [DataMember]
        public UserRoleDto Role { get; set; }        
    }
}