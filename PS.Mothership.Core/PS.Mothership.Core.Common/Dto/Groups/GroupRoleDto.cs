using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class GroupRoleDto
    {
        [DataMember]
        public Guid GroupGuid { get; set; }
        [DataMember]
        public Guid RoleGuid { get; set; }
    }
}
