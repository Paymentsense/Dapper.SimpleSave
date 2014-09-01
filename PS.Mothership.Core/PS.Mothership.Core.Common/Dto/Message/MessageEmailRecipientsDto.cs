using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
    public class MessageEmailRecipientsDto : MessageDto
	{
		[DataMember]
        public Guid MessageEmailRecipientGuid { get; set; }
		[DataMember]
        public EmailAddressDto EmailAddress { get; set; }
		[DataMember]
        public CommMessageEmailAddresstypeEnum MessageEmailAddressTypeKey { get; set; }
	}
}
