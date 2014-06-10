using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
	public class MessageSendTrnDto : MessageDto
	{
		[DataMember]
        public Guid MessageSendGuid { get; set; }
        [DataMember]
        public CommMessageStatusEnum MessageStatusKey { get; set; }
        [DataMember]
        public DateTimeOffset ScheduledDate { get; set; }
	}
}
