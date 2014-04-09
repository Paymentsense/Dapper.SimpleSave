using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
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
