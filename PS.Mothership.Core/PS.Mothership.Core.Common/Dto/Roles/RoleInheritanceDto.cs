using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class RoleInheritanceDto
    {
        [DataMember]
        public Guid ParentRoleGuid { get; set; }
        [DataMember]
        public Guid ChildRoleGuid { get; set; }
    }
}
