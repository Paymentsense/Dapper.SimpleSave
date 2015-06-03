using System;

namespace PS.Mothership.Core.Common.Correlation
{
    public class CorrelationKey
    {
        private readonly Guid _correlationGuid;

        public CorrelationKey()
        {
            _correlationGuid = Guid.NewGuid();
        }

        public CorrelationKey(Guid correlationGuid)
        {
            _correlationGuid = correlationGuid;
        }

        public Guid Guid { get { return _correlationGuid; } }

        public override string ToString()
        {
            return _correlationGuid.ToString();
        }
    }
}