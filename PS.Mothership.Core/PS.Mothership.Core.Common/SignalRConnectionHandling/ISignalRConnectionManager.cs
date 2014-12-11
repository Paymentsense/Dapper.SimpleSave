using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public interface ISignalRConnectionManager
    {
        bool CanAddConnection();
        bool IsLastConnection();
        void RemoveAllConnectionsExcept(Guid connectionGuid);
        bool AddConnection(Guid connectionGuid, bool visible = true);
        bool RemoveConnection(Guid connectionGuid);
        int GetConnectionCount();
        void SetVisibility(Guid connectionGuid, bool visible);
        int GetVisibleCount();
        ICollection<Guid> GetConnectionGuids();
    }
}
