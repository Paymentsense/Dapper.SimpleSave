using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<Role> Roles { get; set; }
    }
}
