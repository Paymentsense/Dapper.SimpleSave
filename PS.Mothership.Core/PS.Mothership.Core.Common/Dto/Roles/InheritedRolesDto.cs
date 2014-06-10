using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class InheritedRolesDto : RoleDto
    {
        [DataMember]
        public List<RoleDto> ChildRoles { get; set; }
    }
}
