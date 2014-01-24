using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class RoleDto
    {
        public RoleDto() { }
        public RoleDto(RoleDto role)
        {
            Id = role.Id;
            RoleName = role.RoleName;
            RoleDescription = role.RoleDescription;
            IsDefining = role.IsDefining;
            RoleStatus = role.RoleStatus;
            RoleStatusName = role.RoleStatusName;
        }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleDescription { get; set; }
        [DataMember]
        public bool IsDefining { get; set; }
        [DataMember]
        public int RoleStatus { get; set; }
        [DataMember]
        public string RoleStatusName { get; set; }
    }
}
