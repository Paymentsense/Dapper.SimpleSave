using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class GroupRoles
    {
        private List<Group> _groups = new List<Group>();

        public List<Group> Groups { get; private set; }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }
    }
}
