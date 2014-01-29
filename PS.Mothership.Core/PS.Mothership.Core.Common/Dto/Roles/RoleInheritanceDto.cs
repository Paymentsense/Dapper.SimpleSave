using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    [DataContract]
    public class RoleInheritanceDto
    {
        [DataMember]
        public long ParentRoleId { get; set; }
        [DataMember]
        public long ChildRoleId { get; set; }
    }
}
