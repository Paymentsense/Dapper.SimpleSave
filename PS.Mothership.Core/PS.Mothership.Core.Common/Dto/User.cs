using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto
{
    public class User
    {
        public Guid UserGuid { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public List<UserAssignedAndAvailableRole> Roles { get; set; }
    }
}
