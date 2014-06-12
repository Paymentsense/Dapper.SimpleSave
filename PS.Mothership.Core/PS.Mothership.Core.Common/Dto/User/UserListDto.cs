using System;

namespace PS.Mothership.Core.Common.Dto.User
{
    public class UserListDto
    {
        public Template.Usr.UsrLoginResultEnum Status { get; set; }

        public Guid UserGuid { get; set; }

        public bool CanImpersonate { get; set; }

        public Template.Usr.UsrStatusOptionFlagEnum StatusOptions { get; set; }

        public string LoginName { get; set; }

        public string UserName { get; set; }

        public bool IsDefining { get; set; }

        public Template.Usr.UsrUserStatusEnum UserStatus { get; set; }

        public string Email { get; set; }

        public Template.Usr.UsrUserTypeEnum UserType { get; set; }

        public Guid SipAccountGuid { get; set; }

        public string DefiningRoleDescription { get; set; }
    }
}
