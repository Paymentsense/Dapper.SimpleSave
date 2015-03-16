using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public abstract class WebApplicationService : IWebApplicationService
    {

    }
}
