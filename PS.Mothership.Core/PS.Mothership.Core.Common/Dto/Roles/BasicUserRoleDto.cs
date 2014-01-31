using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class BasicUserRoleDto
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public long RoleId { get; set; }
    }
}
