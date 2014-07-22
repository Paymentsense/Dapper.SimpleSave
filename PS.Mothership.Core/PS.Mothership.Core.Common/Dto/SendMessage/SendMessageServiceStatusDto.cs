using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
	[DataContract]
	public class SendMessageServiceStatusDto
	{
        [DataMember]
        public IList<MessageServiceStatus> MessageServiceStatus { get; set; }
		[DataMember]
		public DateTimeOffset LastUpdateTime { get; set; }
        [DataMember]
        public CommMessageServiceStatusEnum OverallServiceStatus { get; set; }
        [DataMember]
        public CommMessageTypeEnum MessageType { get; set; }
	}
}
