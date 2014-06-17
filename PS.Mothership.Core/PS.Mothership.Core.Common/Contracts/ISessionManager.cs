using PS.Mothership.Core.Common.Dto.Session;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISessionManager
    {
        SessionHeaderDto SessionInformation { get; set; }
    }
}
