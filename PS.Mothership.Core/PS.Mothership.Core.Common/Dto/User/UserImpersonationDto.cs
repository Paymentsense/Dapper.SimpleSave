using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.User
{
    public class UserImpersonationDto
    {
        public Guid UserGuid { get; set; }

        public string UserName { get; set; }
    }
}
