using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class UserGroupDto
    {
        [DataMember]
        public Guid GroupGuid { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public List<UserRoleDto> Role { get; set; }
    }
}