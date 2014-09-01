using PS.Mothership.Core.Common.Dto.Session;

namespace PS.Mothership.Core.Common.SessionHandling
{
    public interface ISessionManager
    {
        SessionHeaderDto SessionInformation { get; set; }
    }
}
