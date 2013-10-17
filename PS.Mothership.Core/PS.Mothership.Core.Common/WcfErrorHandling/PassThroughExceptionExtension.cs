using System;
using System.ServiceModel.Configuration;
using log4net;


namespace PS.Mothership.Core.Common.WcfErrorHandling
{
    public class PassThroughExceptionExtension : BehaviorExtensionElement
    {
        public ILog _logger { get; set; }

        public PassThroughExceptionExtension()
        {
           
        }

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