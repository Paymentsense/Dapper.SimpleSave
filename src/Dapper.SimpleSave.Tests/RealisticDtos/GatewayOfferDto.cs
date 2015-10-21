using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[GATEWAY_OFFER_TRN]")]
    public class GatewayOfferDto
    {
        [PrimaryKey]
        public Guid? GatewayOfferGuid { get; set; }

        public bool IsBilledYearly { get; set; }

        public decimal PeriodicCharge { get; set; }
    }
}
