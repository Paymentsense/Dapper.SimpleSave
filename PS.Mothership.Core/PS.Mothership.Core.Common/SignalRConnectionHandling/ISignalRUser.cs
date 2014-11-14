namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public interface ISignalRUser
    {
        string Name { get; set; }
        ISignalRConnectionManager ConnectionManager { get; set; }
        void UpdateCollection();
    }
}