using System;
using System.ServiceModel.Configuration;

namespace PS.Mothership.Core.Common.SessionHandling
{

    public class SessionInspectorBehaviorExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new SessionInspectorBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(SessionInspectorBehavior); }
        }
    }
}
