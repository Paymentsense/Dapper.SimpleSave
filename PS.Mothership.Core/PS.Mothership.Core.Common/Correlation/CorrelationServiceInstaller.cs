using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace PS.Mothership.Core.Common.Correlation
{
    public class CorrelationServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<CorrelationKeyProvider>());
            container.Register(Component.For<ICorrelationKeyFactory>().ImplementedBy<SessionCorrelationKeyFactory>());
        }
    }
}