using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class StatusOwnerTransactionDto
    {
        [DataMember]
        public Guid StatusOwnerGuid { get; set; }
        [DataMember]
        public int EventStatusKey { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
    }
}
