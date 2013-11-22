using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class RoleInheritance
    {
        public long ParentRoleId { get; set; }
        public long ChildRoleId { get; set; }
    }
}
