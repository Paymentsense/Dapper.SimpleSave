using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Opp;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class OfferMetaDataDto
    {

        public IEnumerable<OppContractLength> Durations { get; set; }
        public IEnumerable<CountryDto> Countries { get; set; }
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }
        public IEnumerable<OfferAuthorizationFeeDto> AuthorizationFees { get; set; }
        public IEnumerable<OfferMinimumMonthlyServiceChargeDto> MinimumMonthlyServiceCharges { get; set; }
        public int DefaultDuration { get; set; }
        public long DefaultCountryKey { get; set; }
        public long DefaultSalesChannelKey { get; set; }
        public decimal DefaultFee { get; set; }
        public int DefaultFeeKey { get; set; }
        public int DefaultServiceChargeKey { get; set; }



    }
    
}