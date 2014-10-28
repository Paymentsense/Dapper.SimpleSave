using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
	[DataContract]
	public class MessageDto
	{
		[DataMember]
        public Guid MessageGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public CommMessageDirectionEnum MessageDirectionKey { get; set; }
        [DataMember]
        public Guid? CustomerGuid { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
	}
}
