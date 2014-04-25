using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace PS.Mothership.Core.Common.SessionHandling
{
    [AttributeUsage(AttributeTargets.Class)]    
    public class SessionInspectorBehavior : Attribute, IDispatchMessageInspector, IClientMessageInspector
    {
        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var header = request.Headers.GetHeader<SessionHeader>("session-header", "s");
            if (header != null)
            {
                SessionOperationContextExtension.Current.Session.WebSessionGuid = header.WebSessionGuid;
            }
            
            

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }

        #endregion

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var dataToSend = new SessionHeader();
            var typedHeader = new MessageHeader<SessionHeader>(dataToSend);
            var untypedHeader = typedHeader.GetUntypedHeader("session-header", "s");
            

            request.Headers.Add(untypedHeader);
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }
    }
}
