using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
    public class MessageEmailDto : MessageDto
	{
		[DataMember]
        public string Subject { get; set; }
		[DataMember]
        public string MessageBody { get; set; }
		[DataMember]
        public Guid FromEmailAddressGuid { get; set; }
	}
}
