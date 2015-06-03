using System;
using Newtonsoft.Json;
using PS.Mothership.Core.Common.JSON;

namespace PS.Mothership.Core.Common.Correlation
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public class CorrelationKeyProvider
    {
        private readonly ICorrelationKeyFactory _correlationKeyFactory;

        public CorrelationKeyProvider(ICorrelationKeyFactory correlationKeyFactory)
        {
            _correlationKeyFactory = correlationKeyFactory;
        }

        public override string ToString()
        {
            return _correlationKeyFactory.GetCorrelationKey().ToString();
        }

        public Guid GetCorrelationGuid()
        {
            return _correlationKeyFactory.GetCorrelationKey().Guid;
        }
    }

}