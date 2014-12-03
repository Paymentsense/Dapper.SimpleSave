namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public interface IClientsCollection
    {
        ISignalRUser Get(string username);
        ISignalRUser GetOrAdd(string username);
        void AddOrReplace(ISignalRUser inputUser);
    }
}
