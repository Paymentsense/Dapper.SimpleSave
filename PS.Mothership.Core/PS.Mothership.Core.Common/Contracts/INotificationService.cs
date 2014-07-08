namespace PS.Mothership.Core.Common.Contracts
{
    interface INotificationService
    {
        void Subscribe(string applicationName);

        void EndSubscribe(string applicationName);
    }
}
