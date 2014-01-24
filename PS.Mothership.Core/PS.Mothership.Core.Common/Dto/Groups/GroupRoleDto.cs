using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class GroupRoleDto
    {
        [DataMember]
        public long GroupId { get; set; }
        [DataMember]
        public long RoleId { get; set; }
    }
}
