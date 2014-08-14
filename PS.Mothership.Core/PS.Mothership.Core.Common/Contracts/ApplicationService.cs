using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public abstract class ApplicationService : IApplicationService
    {
       
    }
}
 