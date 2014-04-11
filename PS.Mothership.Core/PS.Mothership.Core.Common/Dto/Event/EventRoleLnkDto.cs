using System;
using System.Runtime.Serialization;

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
        public Guid NotificationGuid { get; set; }
    }
}
