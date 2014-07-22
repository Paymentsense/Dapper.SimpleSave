using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
	[DataContract]
	public class SendMessageServiceStatusDto
	{
        [DataMember]
        public IList<MessageServiceStatus> MessageServiceStatus { get; set; }
		[DataMember]
		public DateTimeOffset LastUpdateTime { get; set; }
	}
}
