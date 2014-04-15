using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
