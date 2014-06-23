using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class FullPostcodeDto
    {
        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public long PostCodeKey { get; set; }

        [DataMember]
        public string CountyName { get; set; }

        [DataMember]
        public long CountyKey { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public long CountryKey { get; set; }
    }
}
