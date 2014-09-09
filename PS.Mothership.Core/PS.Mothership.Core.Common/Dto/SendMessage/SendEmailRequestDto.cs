using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
	[DataContract]
	public class SendEmailRequestDto : SendMessageRequestDto
	{
		[DataMember]
		public List<Guid> SendCC { get; set; }
		[DataMember]
		public List<Guid> SendBCC { get; set; }
		[DataMember]
		public string Attachments { get; set; }
		[DataMember]
		public string AttachmentFileNames { get; set; }

	}
}
