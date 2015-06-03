using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace PS.Mothership.Core.Common.Correlation
{
    public class CorrelationWebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<CorrelationKeyProvider>());
            container.Register(Component.For<ICorrelationKeyFactory>().ImplementedBy<PerRequestCorrelationKeyFactory>());

            container.Register(Component.For<ICorrelationKeyFactory>().AsFactory().Named("perWebRequestCorrelationKeyFactory"));
            container.Register(Component.For<CorrelationKey>().Named("CorrelationKey").LifestylePerWebRequest());

            container.Register(Component.For<ICorrelationKeyFactory>().ImplementedBy<SessionCorrelationKeyFactory>().Named("sessionCorrelationKeyFactory"));
        }
    }
}
