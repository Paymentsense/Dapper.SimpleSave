using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
	[DataContract]
	public class MessageReceivedDto
	{
		[DataMember]
		public string Id { get; set; }
		[DataMember]
		public Guid MessageId { get; set; }
		[DataMember]
		public string AccountId { get; set; }
		[DataMember]
		public string Subject { get; set; }
		[DataMember]
		public string MessageText { get; set; }
		[DataMember]
		public string From { get; set; }
		[DataMember]
		public string To { get; set; }
	}
}
