using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum DocSecurityOptionEnum
    {
        [EnumMember]
        OTHER,
        [EnumMember]
        OPEN_PROTECTED
    }
}
