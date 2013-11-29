using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IIdentityCheckService
    {
        [OperationContract]
        IdentityCheckResponseDto GetIdentityScore(IdentityCheckRequestDto creditCheckRequest);

    }
}
