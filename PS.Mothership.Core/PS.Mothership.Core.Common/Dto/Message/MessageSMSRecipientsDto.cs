using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
    public class MessageSMSRecipientsDto : MessageDto
	{
		[DataMember]
        public Guid MessageSMSRecipientGuid { get; set; }
		[DataMember]
        public PhoneNumberDto PhoneNumber { get; set; }
		[DataMember]
        public Guid ServiceResponseID { get; set; }
        [DataMember]
        public DateTimeOffset? ServiceResponseDateTime { get; set; }
	}
}
