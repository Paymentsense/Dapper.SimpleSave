using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    /// <summary>
    /// This is a marker and not to be confused with IApplicationBoardingService which is Domain specific.
    /// </summary>
    [ServiceContract]
    public interface IApplicationService
    {
    }
}