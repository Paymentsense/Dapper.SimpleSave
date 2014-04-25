using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.SessionHandling
{
    public interface IClientSessionHeaderContext
    {
        SessionHeader SessionInformation { get; set; }
    }

    public class ClientSessionHeaderContext : IClientSessionHeaderContext
    {
        public SessionHeader SessionInformation { get; set; }

        public ClientSessionHeaderContext()
        {
            SessionInformation = new SessionHeader();
        }
    }
}