using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IMerchantService
    {


        OfferMetaDataDto GetOfferMetaDataDto(OfferParametersDto parameters);
    }
}
