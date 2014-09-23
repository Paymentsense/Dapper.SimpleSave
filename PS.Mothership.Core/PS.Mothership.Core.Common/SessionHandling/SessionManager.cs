using PS.Mothership.Core.Common.Dto.Session;

namespace PS.Mothership.Core.Common.SessionHandling
{
    public class SessionManager : ISessionManager
    {
        public SessionHeaderDto SessionInformation { get; set; }


        public SessionManager()
        {
            SessionInformation = new SessionHeaderDto();
        }
    }
}
