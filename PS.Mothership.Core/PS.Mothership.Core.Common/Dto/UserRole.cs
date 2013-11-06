using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserRole
    {
        public long UserId { get; set; }
        public Guid UserGuid { get; set; }
        public int RoleId { get; set; }
    }
}
