using PS.Mothership.Core.Common.Template.Gen;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class ParsedPhoneNumberDto
    {
        [DataMember]
        public GenCountryEnum Country { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
