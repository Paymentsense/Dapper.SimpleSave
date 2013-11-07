using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsDefiningRole { get; set; }
    }
}
