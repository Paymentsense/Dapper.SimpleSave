using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Opp;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferMetaDataDto
    {
        [DataMember]
        public IEnumerable<ContractLengthDto> ContractLengths { get; set; }

        [DataMember]
        public IEnumerable<CustomerTypeDto> CustomerTypes { get; set; }
        
        [DataMember]
        public IEnumerable<TypeOfTransactionDto> TypeOfTransactions { get; set; }
        
        [DataMember]
        public IEnumerable<CountryDto> Countries { get; set; }

        [DataMember]
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }

        [DataMember]
        public IEnumerable<RatesRangeDto> RatesRangeCollection { get; set; }

        [DataMember]
        public IEnumerable<OppEquipmentCategory> EquipmentCategories { get; set; }

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