using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.Message
{
    public class InboundMessage
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public Guid AccountId { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public string From { get; set; }
        public IList<string> To { get; set; }
        public DateTime Now { get; set; }
    }
}