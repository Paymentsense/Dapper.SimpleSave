using PS.Mothership.Core.Common.Dto;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IIdentityCheckService
    {
        [OperationContract]
        IdentityCheckResponseDto GetIdentityScore(IdentityCheckRequestDto creditCheckRequest);

    }
}
