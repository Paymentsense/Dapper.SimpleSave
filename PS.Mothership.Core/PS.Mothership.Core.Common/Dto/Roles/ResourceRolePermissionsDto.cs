using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.User;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class ResourceRolePermissionsDto
    {
        [DataMember]
        public UsrResourceEnum ResourceEnum { get; set; }        

        [DataMember]
        public UserRoleDto Role { get; set; }
        
        [DataMember]
        public UsrUserPermissionFlagEnum PermissionEnums { get; set; }        
    }
}