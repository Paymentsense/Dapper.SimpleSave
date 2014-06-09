using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
	[DataContract]
	public class MessageNotificationDto
	{
		[DataMember]
		public bool IsDelivered { get; set; }
		[DataMember]
		public string Id { get; set; }
		[DataMember]
		public string MessageId { get; set; }
		[DataMember]
		public string AccountId { get; set; }
		[DataMember]
		public DateTime OccurredAt { get; set; }
	}
}
