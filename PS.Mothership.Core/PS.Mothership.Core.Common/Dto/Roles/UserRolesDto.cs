using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.Roles
{
    public class UserRolesDto
    {
        //TODO: Refactor wg

        private List<UserDto> _users = new List<UserDto>();
        public List<UserDto> Users 
        {
            get
            {
                return _users;
            }

            private set
            {
                _users = value;
            }
        }

        //public void AddUser(UserDto userVm)
        //{
        //    _users.Add(userVm);
        //}
    }
}
