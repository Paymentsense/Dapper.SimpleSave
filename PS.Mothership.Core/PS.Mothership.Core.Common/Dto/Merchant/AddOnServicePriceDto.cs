using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AddOnServicePriceDto
    {
        [DataMember]
        public Guid AddOnServicePriceGuid { get; set; }

        [DataMember]
        public int AddOnServiceKey { get; set; }

        [DataMember]
        public int AddOnServiceItemKey { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public DateTime EffectiveDate { get; set; }

        [DataMember]
        public double RegularPrice { get; set; }

        [DataMember]
        public double CeilingPrice { get; set; }

        [DataMember]
        public double WholesaleCost { get; set; }

        [DataMember]
        public int CalculatorVersionKey { get; set; }

        [DataMember]
        public double FloorPrice { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public OppProvisionTypeEnum ProvisionTypeKey { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }
    }
}
