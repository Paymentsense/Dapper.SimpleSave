using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
    public class MessageSMSDto : MessageDto
	{
		[DataMember]
        public string MessageBody { get; set; }
        [DataMember]
        public Guid FromPhoneGuid { get; set; }
        [DataMember]
        public string RecipentPhoneNumber { get; set; }
        
	}
}
