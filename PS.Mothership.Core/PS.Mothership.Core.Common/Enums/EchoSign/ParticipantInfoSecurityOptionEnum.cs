using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum ParticipantInfoSecurityOptionEnum
    {
        [EnumMember]
        OTHER,
        [EnumMember]
        KBA,
        [EnumMember]
        WEB_IDENTITY,
        [EnumMember]
        PASSWORD
    }
}
