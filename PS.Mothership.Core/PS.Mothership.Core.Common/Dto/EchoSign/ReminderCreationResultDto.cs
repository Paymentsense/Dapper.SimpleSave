using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class ReminderCreationResultDto
    {
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string RecipientEmail { get; set; }
    }
}
