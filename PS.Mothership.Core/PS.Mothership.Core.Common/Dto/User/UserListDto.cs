using PS.Mothership.Core.Common.Dto.Groups;
using PS.Mothership.Core.Common.Dto.Roles;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.User
{
    [DataContract]
    public class UserListDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public Template.Usr.UsrStatusOptionFlagEnum StatusOptions { get; set; }

        [DataMember]
        public string LoginName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public Template.Usr.UsrUserStatusEnum UserStatus { get; set; }

        [DataMember]
        public Template.Usr.UsrUserTypeEnum UserType { get; set; }

        public bool IsUserPasswordLocked { get { return UserStatus == Template.Usr.UsrUserStatusEnum.PasswordLock; } }

        [DataMember]
        public bool UnlockAccount { get; set; }

        [DataMember]
        public bool ResetPassword { get; set; }

        [DataMember]
        public ICollection<RoleDto> Roles { get; set; }

        [DataMember]
        public ICollection<GroupDto> Groups { get; set; }

        public GroupDto DefiningGroup
        {
            get
            {
                if (DefiningRole == null) return null;
                return
                    (from g in Groups
                     from r in g.Roles
                     where r.RoleGuid == DefiningRole.RoleGuid
                     select g).FirstOrDefault();
            }
        }

        public RoleDto DefiningRole
        {
            get
            {
                return Roles.Union(Groups.SelectMany(x => x.Roles)).FirstOrDefault(x => x.IsDefining);
            }
        }

        [DataMember]
        public Guid SipAccountGuid { get; set; }

        [DataMember]
        public string EMail { get; set; }
    }
}
