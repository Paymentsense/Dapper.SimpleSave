using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class PrivateInformationTypeDto
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ForeName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public int DateOfBirthDay { get; set; }
        [DataMember]
        public int DateOfBirthMonth { get; set; }
        [DataMember]
        public int DateOfBirthYear { get; set; }
        [DataMember]
        public Gender Gender { get; set; }
    }
}
