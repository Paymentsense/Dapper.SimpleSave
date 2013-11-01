using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserRoles
    {
        private List<User> _users = new List<User>();
        public List<User> Users 
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

        public void AddGroup(User userVm)
        {
            _users.Add(userVm);
        }
    }
}
