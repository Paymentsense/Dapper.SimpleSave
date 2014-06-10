using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public long CountryKey { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public string TelephoneCountryCode { get; set; }
    }
}
