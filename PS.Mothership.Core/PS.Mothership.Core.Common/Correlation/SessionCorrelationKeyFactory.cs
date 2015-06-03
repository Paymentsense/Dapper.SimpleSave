using Castle.Windsor;
using PS.Mothership.Core.Common.SessionHandling;

namespace PS.Mothership.Core.Common.Correlation
{
    public class SessionCorrelationKeyFactory : ICorrelationKeyFactory
    {
        private readonly IWindsorContainer _container;

        public SessionCorrelationKeyFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public CorrelationKey GetCorrelationKey()
        {
            var sessionManager = _container.Resolve<ISessionManager>();//TODO: Remove this when factory method has been merged into branch. [ChrisL, 18,05,2015]
            return new CorrelationKey(sessionManager.SessionInformation.CorrelationGuid);
        }
    }
}
