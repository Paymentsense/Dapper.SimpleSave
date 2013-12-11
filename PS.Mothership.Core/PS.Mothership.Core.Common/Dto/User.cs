using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class User
    {
        public Guid UserGuid { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Role> AssignedRoles { get; set; }
        public List<Role> AvailableRoles { get; set; }
    }
}
