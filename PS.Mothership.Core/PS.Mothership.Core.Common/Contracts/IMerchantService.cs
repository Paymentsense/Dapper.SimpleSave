using System;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "MerchantService")]
    public interface IMerchantService
    {
        [OperationContract]
        OfferMetaDataDto GetOfferMetaDataDto();

        [OperationContract]
        OfferDto GetOffer(Guid offerGuid);

        [OperationContract]
        OfferDto SaveOrUpdateOffer(OfferDto offer);

        [OperationContract]
        OpportunityLatestOfferDto GetOpportunity(Guid id);
    }
}
