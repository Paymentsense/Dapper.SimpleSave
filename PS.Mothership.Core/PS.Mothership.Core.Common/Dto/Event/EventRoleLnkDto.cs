using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Roles;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class EventRoleLnkDto
    {
        [DataMember]
        public Guid EventRoleGuid { get; set; }
        [DataMember]
        public Guid RoleGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
        [DataMember]
        public EventTransactionDto Event { get; set; }
        [DataMember]
        public RoleDto Role { get; set; }
    }
}
