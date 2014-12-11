using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class UserGroupDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid GroupGuid { get; set; }
    }
}
