using System;
using System.ServiceModel.Configuration;
using log4net;


namespace PS.Mothership.Core.Common.WcfErrorHandling
{
    public class PassThroughExceptionExtension : BehaviorExtensionElement
    {
        public ILog Logger { get; set; }

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