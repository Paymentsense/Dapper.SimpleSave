using PS.Mothership.Core.Common.Template.Gen;
using System.Runtime.Serialization;

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
    }
}
