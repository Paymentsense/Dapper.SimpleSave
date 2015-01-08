using PS.Mothership.Core.Common.Template.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Application
{
    public class PrincipalAddressDto
    {
        public FullAddressDto Address { get; set; }

        public AppPremisesOwnershipTypeEnum OwnershipType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
