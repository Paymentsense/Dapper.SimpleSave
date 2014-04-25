using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace PS.Mothership.Core.Common.SessionHandling
{
    [AttributeUsage(AttributeTargets.Class)]    
    public class SessionInspectorBehavior : Attribute, IDispatchMessageInspector//, IClientMessageInspector
    {
        private readonly ISessionManager _sessionManager;

        public SessionInspectorBehavior(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }


        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var header = request.Headers.GetHeader<SessionHeader>("session-header", "s");
            //SessionOperationContextExtension.Current.Session.WebSessionGuid = header != null ?  header.WebSessionGuid : Guid.Empty;
            _sessionManager.SessionInformation.WebSessionGuid = header != null ?  header.WebSessionGuid : Guid.Empty;
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IClientMessageInspector

        //public object BeforeSendRequest(ref Message request, IClientChannel channel)
        //{
        //    var dataToSend = new SessionHeader();
        //    var typedHeader = new MessageHeader<SessionHeader>(dataToSend);
        //    var untypedHeader = typedHeader.GetUntypedHeader("session-header", "s");
        //    request.Headers.Add(untypedHeader);
        //    return null;
        //}

        //public void AfterReceiveReply(ref Message reply, object correlationState)
        //{
        //    throw new NotImplementedException();
        //}


        #endregion
    }
}
