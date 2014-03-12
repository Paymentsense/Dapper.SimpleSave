using System;

namespace PS.Mothership.Core.Common.Helper
{
    public interface ISignalRConnectionManager
    {
        bool CanAddConnection();
        bool IsLastConnection();
        void RemoveAllConnectionsExcept(Guid connectionGuid);
        bool AddConnection(Guid connectionGuid, bool visible = true);
        bool RemoveConnection(Guid connectionGuid);
        int Count();
        void SetVisibility(Guid connectionGuid, bool visible);
        int CountVisible();
    }
}
