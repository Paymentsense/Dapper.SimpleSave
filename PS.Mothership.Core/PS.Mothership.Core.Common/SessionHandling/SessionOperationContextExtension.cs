using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Common.Logging;

namespace PS.Mothership.Core.Common.SessionHandling
{
    public class SessionOperationContextExtension : IExtension<OperationContext>
    {
        private readonly SessionHeader _sessionHeader;
        public ILog Logger { get; set; }

        public SessionOperationContextExtension()
        {
            _sessionHeader = new SessionHeader();
        }

        public static SessionOperationContextExtension Current
        {
            get
            {
                var context = OperationContext.Current.Extensions.Find<SessionOperationContextExtension>();
                if (context == null)
                {
                    context = new SessionOperationContextExtension();
                    OperationContext.Current.Extensions.Add(context);
                }
                return context;
            }
        }


        public SessionHeader Session
        {
            get { return _sessionHeader; }
        }

        public void Attach(OperationContext owner)
        {
            Logger.Info("SessionHeader attached to new OperationContext");
        }

        public void Detach(OperationContext owner)
        {
            Logger.Info("SessionHeader detached to OperationContext");
        }
    }
}
