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
        public string CountryName { get; set; }
    }
}
