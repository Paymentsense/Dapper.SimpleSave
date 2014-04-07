using System;
using System.Collections.Generic;
using System.ServiceModel;
using Microsoft.Practices.ServiceLocation;
using PS.Mothership.Core.Common.Config;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    public class DtoEvents
    {
        public static void Raise<T>(T args) where T : IDtoEvent
        {
            foreach (var handler in ServiceLocator.Current.GetAllInstances<IHandles<T>>())
            {
                handler.Handle(args);
            }
        }
    }
}