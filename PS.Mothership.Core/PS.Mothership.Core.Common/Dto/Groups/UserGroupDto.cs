using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class UserGroupDto
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public long GroupId { get; set; }
    }
}
