using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class BasicUserRoleDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid RoleGuid { get; set; }
    }
}
