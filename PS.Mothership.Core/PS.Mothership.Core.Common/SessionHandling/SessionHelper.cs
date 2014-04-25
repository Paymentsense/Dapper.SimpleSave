using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.SessionHandling
{
    public interface ISessionManager
    {
        SessionHeader SessionInformation { get; set; }
    }

    public class SessionHelper : ISessionManager
    {
        public SessionHeader SessionInformation { get; set; }

        public SessionHelper()
        {
            SessionInformation = new SessionHeader();
        }
    }
}