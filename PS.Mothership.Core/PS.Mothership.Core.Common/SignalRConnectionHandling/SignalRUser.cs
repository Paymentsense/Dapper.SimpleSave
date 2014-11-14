namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public class SignalRUser : ISignalRUser
    {
        private IClientsCollection _clientsCollection;

        public string Name { get; set; }
        public ISignalRConnectionManager ConnectionManager { get; set; }

        public SignalRUser(IClientsCollection clientsCollection, ISignalRConnectionManager connectionManager)
        {
            _clientsCollection = clientsCollection;
            ConnectionManager = connectionManager;
        }

        public void UpdateCollection()
        {
            _clientsCollection.AddOrReplace(this);
        }
    }
}