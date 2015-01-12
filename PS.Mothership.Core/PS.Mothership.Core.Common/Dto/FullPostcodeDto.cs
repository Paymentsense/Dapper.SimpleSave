using PS.Mothership.Core.Common.Template.Gen;
using System.Linq;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{

    [DataContract]
    public class FullPostcodeDto
    {
        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public int PostCodeKey { get; set; }

        [DataMember]
        public string CountyName { get; set; }

        [DataMember]
        public int CountyKey { get; set; }

        [DataMember]
        public string CountryName
        {
            get
            {
                var genCountry = GenCountryCollection.GenCountryList.FirstOrDefault(x => x.CountryKey == (int)CountryKey);
                return genCountry != null ? genCountry.EnumDescription : string.Empty;
            }
        }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }
    }
}
