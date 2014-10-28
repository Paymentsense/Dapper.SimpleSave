using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    /// <summary>
    /// This is a base class and not to be confused with IApplicationBoardingService implementation which is Domain specific.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public abstract class ApplicationService : IApplicationService
    {
       
    }
}
 