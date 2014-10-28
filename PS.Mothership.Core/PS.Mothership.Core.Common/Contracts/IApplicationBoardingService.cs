using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ApplicationBoardingService")]
    public interface IApplicationBoardingService
    {
        [OperationContract]
        ApplicationOpportunitiesDto GetApplicationOpportunities();

        [OperationContract]
        void SaveApplicationOpportunities(ApplicationOpportunitiesDto applicationOpportunitiesDto);

        [OperationContract]
        ApplicationDetailsDto GetApplicationDetails();

        [OperationContract]
        void SaveApplicationDetails(ApplicationDetailsDto applicationDetailsDto);

    }
}