using System;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class MerchantEventLnkDto
    {
        public Guid MerchantEventLnkGuid { get; set; }

        public Guid EventGuid { get; set; }

        public Guid MerchantGuid { get; set; }
    }
}
