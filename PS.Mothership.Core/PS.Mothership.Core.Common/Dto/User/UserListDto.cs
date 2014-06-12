using System;

namespace PS.Mothership.Core.Common.Dto.User
{
    public class UserListDto
    {
        public Guid UserGuid { get; set; }

        public Template.Usr.UsrStatusOptionFlagEnum StatusOptions { get; set; }

        public string LoginName { get; set; }

        public string UserName { get; set; }

        public Template.Usr.UsrUserStatusEnum UserStatus { get; set; }
        
        public Template.Usr.UsrUserTypeEnum UserType { get; set; }
        
        public string DefiningRoleDescription { get; set; }
    }
}
