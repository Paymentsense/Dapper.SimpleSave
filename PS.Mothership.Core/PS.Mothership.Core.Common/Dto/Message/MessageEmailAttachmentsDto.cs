using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
    public class MessageEmailAttachmentsDto : MessageDto
	{
		[DataMember]
        public Guid MessageEmailAttachmentGuid { get; set; }
		[DataMember]
        public string FileName { get; set; }
		[DataMember]
        public string FileLocation { get; set; }
	}
}
