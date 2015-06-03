using System;
using System.ServiceModel;
using System.Web;

namespace PS.Mothership.Core.Common.Correlation
{
    public class PerRequestCorrelationKeyFactory : ICorrelationKeyFactory
    {
        private readonly ICorrelationKeyFactory _perWebRequestCorrelationKeyFactory;
        private readonly ICorrelationKeyFactory _sessionCorrelationKeyFactory;

        public PerRequestCorrelationKeyFactory(ICorrelationKeyFactory perWebRequestCorrelationKeyFactory, ICorrelationKeyFactory sessionCorrelationKeyFactory)
        {
            _perWebRequestCorrelationKeyFactory = perWebRequestCorrelationKeyFactory;
            _sessionCorrelationKeyFactory = sessionCorrelationKeyFactory;
        }

        public CorrelationKey GetCorrelationKey()
        {
            var isHttpRequest = HttpContext.Current != null;
            if (isHttpRequest)
            {
                return _perWebRequestCorrelationKeyFactory.GetCorrelationKey();
            }

            var isWcfOperation = OperationContext.Current != null;
            if (isWcfOperation)
            {
                return _sessionCorrelationKeyFactory.GetCorrelationKey();
            }

            return new CorrelationKey();
        }
    }
}