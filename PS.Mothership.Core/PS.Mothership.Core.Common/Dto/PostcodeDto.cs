using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class PostcodeDto
    {
        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public long PostCodeKey { get; set; }
    }
}
