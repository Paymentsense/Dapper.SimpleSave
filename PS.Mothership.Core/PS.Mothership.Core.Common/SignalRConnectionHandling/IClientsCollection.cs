namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public interface IClientsCollection
    {
        ISignalRUser Get(string machineName, string username);
        ISignalRUser GetOrAdd(string machineName, string username);
        void AddOrReplace(ISignalRUser inputUser);
    }
}
