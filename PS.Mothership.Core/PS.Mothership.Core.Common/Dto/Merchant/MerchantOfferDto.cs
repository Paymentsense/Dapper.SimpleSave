using PS.Mothership.Core.Common.Template.Gen;
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

        public string Description { get; set; }

        public GenOpportunityStatus Status { get; set; }

        public string StatusDescription
        {
            get
            {
                return GenOpportunityStatusCollection.GenOpportunityStatusList.Single(x => x.EnumValue == Status.EnumValue).EnumDescription;
            }
        }

        public decimal Credit { get; set; }

        public decimal Debit { get; set; }

        public ContractLengthDto Duration { get; set; }

        public string DurationDescription
        {
            get
            {
                return Duration.Description;
            }
        }

        public DateTimeOffset UpdateDate { get; set; }

        public string UpdateUsername { get; set; }
    }
}
