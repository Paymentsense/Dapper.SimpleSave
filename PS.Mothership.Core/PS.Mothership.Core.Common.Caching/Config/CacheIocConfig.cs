using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.ApplicationServer.Caching;
using PS.Mothership.Caching.Contracts;
using PS.Mothership.Caching.Implementations;
using PS.Mothership.Core.Common.Config;

namespace PS.Mothership.Caching.Config
{
    public class CacheIocConfig : ILayerIocBuilder
    {
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public IWindsorContainer Configure(IocBuildSettings settings = null, IWindsorContainer container = null)
        {
            container = container ?? new WindsorContainer();
            settings = settings ?? new IocBuildSettings();

            var configuration = new DataCacheFactoryConfiguration
            {
                LocalCacheProperties = new DataCacheLocalCacheProperties(),
                //TODO: Cache Security - is set to None
                SecurityProperties = new DataCacheSecurity(DataCacheSecurityMode.None, DataCacheProtectionLevel.None)
            };

            container.Register(Component.For<DataCacheFactory>()
                .Instance(new DataCacheFactory(configuration))
                .LifeStyle.Transient);

            container.Register(Component.For<ICacheConfig>()
                .ImplementedBy<CacheConfig>()
                .LifeStyle.Transient);

            return container;
        }

        public static CacheIocConfig New()
        {
            return new CacheIocConfig();
        }
    }
}
