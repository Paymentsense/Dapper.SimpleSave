using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Contact;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class ExperianDetailsDto
    {
        [DataMember]
        public Guid ExperianIdCheckGuid { get; set; }

        [DataMember]
        public string AuthenticationIndex { get; set; }//score

        [DataMember]
        public string AuthenticationText { get; set; }

        [DataMember]
        public string ExperianReferenceNumber { get; set; }

        [DataMember]
        public DateTimeOffset SearchDateTime { get; set; }

        [DataMember]
        public string ForeName { get; set; }

        [DataMember]
        public string SurName { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public AddressDto CurrentAddress { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public AddressDto PreviousAddress { get; set; }

        [DataMember]
        public string PreviousPostCode { get; set; }
    }
}
