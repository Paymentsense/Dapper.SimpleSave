using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Enums
{
    [DataContract]
    public enum StatusType
    {
        [DataMember]
        Success,
        [DataMember]
        Info,
        [DataMember]
        Warning,
        [DataMember]
        Error
    }
}
