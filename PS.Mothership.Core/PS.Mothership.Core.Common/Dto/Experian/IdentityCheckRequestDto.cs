using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class IdentityCheckRequestDto
    {

        [DataMember]
        public Guid ExperianIdCheckGuid { get; set; }

        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public PrivateInformationTypeDto PersonalInformation { get; set; }
        [DataMember]
        public CurrentAddressTypeDto CurrentAddress { get; set; }
        [DataMember]
        public PreviousAddressTypeDto PreviousAddress { get; set; }
        [DataMember]
        public bool CreateDocument { get; set; }

    }

}
