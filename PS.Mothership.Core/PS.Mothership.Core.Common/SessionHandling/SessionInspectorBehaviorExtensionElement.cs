using System;
using System.ServiceModel.Configuration;

namespace PS.Mothership.Core.Common.SessionHandling
{

    public class SessionInspectorBehaviorExtensionElement : BehaviorExtensionElement
    {
        public ISessionManager SessionManager { get; set; }

       
        protected override object CreateBehavior()
        {
            return new SessionInspectorBehavior(SessionManager);
        }

        public override Type BehaviorType
        {
            get { return typeof(SessionInspectorBehavior); }
        }
    }
}
