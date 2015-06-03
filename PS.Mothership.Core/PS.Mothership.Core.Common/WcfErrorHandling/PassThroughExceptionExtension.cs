using System;
using System.ServiceModel.Configuration;

namespace PS.Mothership.Core.Common.WcfErrorHandling
{
    public class PassThroughExceptionExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(PassThroughExceptionHandlingBehaviour); }
        }

        protected override object CreateBehavior()
        {
            //System.Diagnostics.Debugger.Launch();
            return new PassThroughExceptionHandlingBehaviour();
        }
    }
}