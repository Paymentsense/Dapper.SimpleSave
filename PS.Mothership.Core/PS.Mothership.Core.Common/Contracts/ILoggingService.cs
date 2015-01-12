using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "LoggingService")]
    public interface ILoggingService
    {
        [OperationContract] void Log(string messageToLog);
    }
}