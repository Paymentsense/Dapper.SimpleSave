using System;

namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public interface IClientsCollection
    {
        ISignalRUser Get(string username);
        ISignalRUser GetOrAdd(string username, Func<string, ISignalRUser> addFunc);
        void AddOrReplace(ISignalRUser inputUser);
    }
}
