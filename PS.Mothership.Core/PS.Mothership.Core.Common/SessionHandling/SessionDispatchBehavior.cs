using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Castle.Windsor;

namespace PS.Mothership.Core.Common.SessionHandling
{

    public class SessionDispatchBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        private readonly IWindsorContainer _container;

        public SessionDispatchBehavior(IWindsorContainer container)
        {
            _container = container;
        }


        protected override object CreateBehavior()
        {
            return this;
        }

        public override Type BehaviorType
        {
            get { return GetType(); }
        }

        #region IEndpointBehavior

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            if (endpointDispatcher.DispatchRuntime.MessageInspectors.OfType<SessionDispatchInspector>().Any())
                return;

            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(_container.Resolve<IDispatchMessageInspector>());
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        #endregion

       
    }
}
