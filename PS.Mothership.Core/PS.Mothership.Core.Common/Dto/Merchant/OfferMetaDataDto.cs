using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Opp;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class OfferMetaDataDto
    {

        public ICollection<OppContractLengthEnum> Durations { get; set; }
        public IEnumerable<CountryDto> Countries { get; set; }
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }
        public IEnumerable<OfferAuthorizationFeeDto> AuthorizationFees { get; set; }
        public IEnumerable<OfferMinimumMonthlyServiceChargeDto> MinimumMonthlyServiceCharges { get; set; }

    }
}