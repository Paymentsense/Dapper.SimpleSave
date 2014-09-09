using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferMetaDataDto
    {
        [DataMember]
        public IEnumerable<OppContractLength> Durations { get; set; }

        [DataMember]
        public IEnumerable<OppCustomerType> CustomerTypes { get; set; }
        
        [DataMember]
        public IEnumerable<OppTypeOfTransactions> ProductType { get; set; }
        
        [DataMember]
        public IEnumerable<CountryDto> Countries { get; set; }

        [DataMember]
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }

        [DataMember]
        public IEnumerable<RatesRangeDto> RatesRangeCollection { get; set; }

        [DataMember]
        public IEnumerable<OppEquipmentCategory> EquipmentCatogories { get; set; }

        [DataMember]
        public IEnumerable<EquipmentModelDto> EquipmentModels { get; set; } 
        
        [DataMember]
        public IEnumerable<OfferAuthorizationFeeDto> AuthorizationFees { get; set; }

        [DataMember]
        public IEnumerable<OfferMinimumMonthlyServiceChargeDto> MinimumMonthlyServiceCharges { get; set; }

        [DataMember]
        public IEnumerable<OfferConstraintsLnkDto> OfferConstraints { get; set; }

        [DataMember]
        public IEnumerable<OfferFieldLutDto> OfferFields { get; set; }

    }
    
}