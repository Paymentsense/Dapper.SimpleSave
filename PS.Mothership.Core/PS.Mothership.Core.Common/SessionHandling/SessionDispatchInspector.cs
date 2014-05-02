using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace PS.Mothership.Core.Common.SessionHandling
{
    public class SessionDispatchInspector : IDispatchMessageInspector
    {
        private readonly ISessionManager _sessionManager;

        public SessionDispatchInspector(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }


        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var findHeader = request.Headers.FindHeader("session-header", "s");
            var header = findHeader != -1 ? request.Headers.GetHeader<SessionHeader>("session-header", "s") : null;
            //SessionOperationContextExtension.Current.Session.WebSessionGuid = header != null ?  header.WebSessionGuid : Guid.Empty;
            _sessionManager.SessionInformation.WebSessionGuid = header != null ?  header.WebSessionGuid : Guid.Empty;
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }

        #endregion
       
    }
}
