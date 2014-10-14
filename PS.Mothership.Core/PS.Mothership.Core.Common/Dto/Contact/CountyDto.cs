using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class CountyDto
    {
        [DataMember]
        public int CountyKey { get; set; }

        [DataMember]
        public string CountyName { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

        [DataMember]
        public CountryDto Country { get; set; }
    }
}
