using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;

namespace PS.Mothership.Core.Common.Dto.Merchant
{

    [DataContract]
    public class OfferMetadataDataRequestDto
    {
        [DataMember]
        public int CountryKey { get; set; } // UK or ROI

        [DataMember]
        public int SalesChannel { get; set; } // Telesales, Field North, FieldSouth

        [DataMember]
        public int CustomerType { get; set; } // NTC Switcher, or Switcher (No Statement)

        [DataMember]
        public int ProductType { get; set; }  // F2F, ECOM, MOTO, EPOS, PSConnect (Terminal), PSConnect (ECom)
    }
}