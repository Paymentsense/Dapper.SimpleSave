using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace PS.Mothership.Core.Common.SessionHandling
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionInspectorBehavior : Attribute, IDispatchMessageInspector
    {
        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var header = request.Headers.GetHeader<SessionHeader>("session-header", "s");


            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
