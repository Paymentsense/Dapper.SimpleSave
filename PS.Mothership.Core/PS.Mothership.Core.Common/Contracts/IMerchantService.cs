using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "MerchantService")]
    public interface IMerchantService
    {
        [OperationContract]
        OfferMetaDataDto GetOfferMetaDataDto(OfferMetadataDataRequestDto dataRequestDto);

        [OperationContract]
        OfferDto UpdateOffer(OfferDto offer);

    }
}
