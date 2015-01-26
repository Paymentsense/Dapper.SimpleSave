using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Application;
using PS.Mothership.Core.Common.Dto.DynamicRequest;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ApplicationBoardingService")]
    public interface IApplicationBoardingService
    {
        [OperationContract]
        ApplicationOpportunitiesDto GetApplicationOpportunities(Guid applicationGuid);

        [OperationContract]
        ApplicationOpportunitiesDto SaveApplicationOpportunities(ApplicationOpportunitiesDto applicationOpportunitiesDto);

        [OperationContract]
        ApplicationOpportunitiesMetadataDto GetApplicationOpportunitiesMetadata();

        [OperationContract]
        ApplicationDetailsMetadataDto GetApplicationDetailsMetadata();

        [OperationContract]
        ApplicationDetailsDto GetApplicationDetails(Guid applicationGuid);

        [OperationContract]
        ApplicationDetailsDto SaveApplicationDetails(ApplicationDetailsDto applicationDetailsDto);

        [OperationContract]
        ApplicationInfoDto GetApplicationInfo(Guid applicationGuid);

        [OperationContract]
        IEnumerable<MerchantCategoryCodeDto> GetMerchantCategoryCodes(DataRequestDto dataRequestDto);
        [OperationContract]
        IEnumerable<MerchantCategoryCodeDto> GetAllMerchantCategoryCodes();
    }
}