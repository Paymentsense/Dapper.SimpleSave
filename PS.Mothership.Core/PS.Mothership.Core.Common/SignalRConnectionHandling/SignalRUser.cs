using System;
using System.Runtime.Serialization;
using Castle.Windsor;

namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    [DataContract]
    public class SignalRUser : SignalRConnectionManager, ISignalRUser
    {
        private IClientsCollection _clientsCollection;

        [DataMember]
        public string Name { get; set; }

        public SignalRUser(IClientsCollection clientsCollection)
        {
            _clientsCollection = clientsCollection;
        }

        public void SetClientCollection(IWindsorContainer container)
        {
            _clientsCollection = container.Resolve<IClientsCollection>();
        }

        public void UpdateCollection()
        {
            _clientsCollection.AddOrReplace(this);
        }

        public override bool AddConnection(Guid connectionGuid, bool visible = true)
        {
            var success = base.AddConnection(connectionGuid, visible);

            if (success)
                UpdateCollection();

            return success;
        }

        public override bool RemoveConnection(Guid connectionGuid)
        {
            var success = base.RemoveConnection(connectionGuid);

            if (success)
                UpdateCollection();

            return success;
        }

        public override void SetVisibility(Guid connectionGuid, bool visible)
        {
            base.SetVisibility(connectionGuid, visible);

            UpdateCollection();
        }
    }
}