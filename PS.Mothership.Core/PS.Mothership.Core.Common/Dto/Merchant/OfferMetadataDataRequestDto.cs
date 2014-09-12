using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;

namespace PS.Mothership.Core.Common.Dto.Merchant
{

    public class OfferMetadataDataRequestDto
    {
        public int CountryKey { get; set; } // UK or ROI

        public int SalesChannel { get; set; } // Telesales, Field North, FieldSouth

        public OppCustomerTypeEnum CustomerType { get; set; } // NTC Switcher, or Switcher (No Statement)

        public GenTypeOfTransactionEnum ProductType { get; set; }  // F2F, ECOM, MOTO, EPOS, PSConnect (Terminal), PSConnect (ECom)
    }
}