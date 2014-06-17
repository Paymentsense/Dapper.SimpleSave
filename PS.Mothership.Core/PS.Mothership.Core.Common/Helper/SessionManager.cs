using PS.Mothership.Core.Common.Contracts;
using PS.Mothership.Core.Common.Dto.Session;

namespace PS.Mothership.Core.Common.Helper
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
