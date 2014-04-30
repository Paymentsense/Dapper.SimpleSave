using System;
using System.ServiceModel.Configuration;

namespace PS.Mothership.Core.Common.SessionHandling
{

    public class SessionInspectorBehaviorExtensionElement : BehaviorExtensionElement
    {
        private readonly ISessionManager _sessionManager;

        public SessionInspectorBehaviorExtensionElement(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        protected override object CreateBehavior()
        {
            return new SessionInspectorBehavior(_sessionManager);
        }

        public override Type BehaviorType
        {
            get { return typeof(SessionInspectorBehavior); }
        }
    }
}
