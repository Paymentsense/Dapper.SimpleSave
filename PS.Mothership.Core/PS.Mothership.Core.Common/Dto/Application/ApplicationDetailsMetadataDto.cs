using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.App;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailsMetadataDto
    {
        [DataMember]
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }

        [DataMember]
        public IList<GenBusinessLegalType> BusinessLegalTypes { get; set; }

        [DataMember]
        public IList<AppAdvertisingFlags> AdvertisingTypes { get; set; }

        [DataMember]
        public IList<AppPremisesType> PremisesTypes { get; set; }

        [DataMember]
        public IList<GenSalutation> SalutationTypes { get; set; }

        [DataMember]
        public IList<GenContactRole> ContactRoles { get; set; } 

        [DataMember]
        public IEnumerable<GenCountry> Countries { get; set; }

        [DataMember]
        public IEnumerable<GenCurrencyCode> Currencies { get; set; }

        [DataMember]
        public IEnumerable<CustomerTypeDto> CustomerTypes { get; set; }

        [DataMember]
        public IEnumerable<TypeOfTransactionDto> TypeOfTransactions { get; set; }

        [DataMember]
        public IEnumerable<ContractLengthDto> ContractLengths { get; set; }

        [DataMember]
        public IEnumerable<AddOnServiceDto> AddOns { get; set; }

        [DataMember]
        public IEnumerable<EquipmentModelMetadataDto> EquipmentModels { get; set; }

        [DataMember]
        public IEnumerable<GatewayTariffDto> GatewayTariffs { get; set; }
    }
}
