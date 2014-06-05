using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class MerchantAddressDto
    {
        public Guid MerchantGuid { get; set; }

        public FullAddressDto Address { get; set; }
    }
}
