using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Application;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "MerchantService")]
    public interface IMerchantService
    {
        [OperationContract]
        OfferMetaDataDto GetOfferMetaDataDto(int versionKey);

        [OperationContract]
        OfferDto GetOffer(Guid offerGuid);

        [OperationContract]
        OfferDto SaveOrUpdateOffer(OfferDto offer);

        [OperationContract]
        OpportunityLatestOfferDto GetOpportunity(Guid id);

        [OperationContract]
        IEnumerable<ApplicationSummaryDto> GetApplicationSummaries(Guid merchantGuid);

        [OperationContract]
        IEnumerable<PhoneCountryCodeMetadataDto> GetPhoneCountryCodeMetadata();

        [OperationContract]
        IEnumerable<MerchantHistoryDto> GetLastViewedMerchants(Guid userGuid, int count);
    }
}
