using PS.Mothership.Core.Common.Template.Opp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class MerchantOfferDto
    {
        public Guid CustomerGuid { get; set; }

        public Guid OfferGuid { get; set; }

        public string Reference { get; set; }

        public OppOpportunityStatusEnum Status { get; set; }

        public Decimal Credit { get; set; }

        public Decimal Debit { get; set; }

        public OppContractLengthEnum Duration { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public string UpdateUsername { get; set; }
    }
}
