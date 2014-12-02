using Castle.Windsor;

namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public interface ISignalRUser : ISignalRConnectionManager
    {
        string Name { get; set; }
        void UpdateCollection();
        void SetClientCollection(IWindsorContainer container);
    }
}