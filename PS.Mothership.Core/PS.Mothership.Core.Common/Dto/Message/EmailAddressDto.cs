using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
	public class EmailAddressDto
	{
		[DataMember]
        public Guid EmailAddressGuid { get; set; }
		[DataMember]
        public string EmailAddress { get; set; }
		[DataMember]
        public long ReasonKey { get; set; }
		[DataMember]
        public Guid UpdateSessionGuid { get; set; }
		[DataMember]
        public DateTimeOffset UpdateDate { get; set; }
	}
}
