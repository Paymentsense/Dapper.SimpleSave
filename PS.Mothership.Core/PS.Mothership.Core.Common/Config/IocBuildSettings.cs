using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Config
{
    public class IocBuildSettings
    {
        public bool IsInTestMode { get; set; }
        public WcfMode WcfMode { get; set; }
        public string WcfBaseAddress { get; set; }
        public Dictionary<Type, object> ApplicationServices { get; set; }
        public Dictionary<Type, object> Repositories { get; set; }

        public IocBuildSettings()
        {
            WcfMode = WcfMode.InProcess;
        }

        public static IocBuildSettings New()
        {
            return new IocBuildSettings();
        }

        public IocBuildSettings WithRepository<T>(object instanceType)
        {
            if (Repositories == null)
                Repositories = new Dictionary<Type, object>();

            Repositories.Add(typeof(T), instanceType);

            return this;
        }

        public IocBuildSettings WithRepository(Type registerAsType, object instanceType)
        {
            if (Repositories == null)
                Repositories = new Dictionary<Type, object>();

            Repositories.Add(registerAsType, instanceType);

            return this;
        }

        public IocBuildSettings WithApplicationService(Type registerAsType, object instanceType)
        {
            if (ApplicationServices == null)
                ApplicationServices = new Dictionary<Type, object>();
            
            ApplicationServices.Add(registerAsType, instanceType);

            return this;
        }

        public IocBuildSettings WithApplicationServices(Dictionary<Type, object> appServices)
        {
            ApplicationServices = appServices;
            return this;
        }

        public IocBuildSettings InWcfMode(WcfMode mode)
        {
            WcfMode = mode;
            return this;
        }

        public IocBuildSettings WithWcfServicesBaseAddress(string baseAddress)
        {
            WcfBaseAddress = baseAddress;
            return this;
        }

        public IocBuildSettings InTestMode()
        {
            IsInTestMode = true;
            return this;
        }
    }
}