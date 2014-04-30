using System;
using Castle.Windsor;

namespace PS.Mothership.Core.Common.Config
{
    public interface ILayerIocBuilder : IDisposable
    {
        IWindsorContainer Configure(IocBuildSettings settings = null, IWindsorContainer container = null);

    }
}