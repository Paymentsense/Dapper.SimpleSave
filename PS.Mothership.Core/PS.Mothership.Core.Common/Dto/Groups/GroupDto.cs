using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class GroupDto
    {
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string GroupDescription { get; set; }
        [DataMember]
        public Guid GroupGuid { get; set; }
        [DataMember]
        public List<RoleDto> Roles { get; set; }
    }
}
