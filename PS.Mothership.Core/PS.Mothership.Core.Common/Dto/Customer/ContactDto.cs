using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    [DataContract]
    public class ContactDto
    {
        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public virtual string Email { get; set; }        

        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string SurName { get; set; }

        [DataMember]
        public virtual string MobileNumber { get; set; }

        [DataMember]
        public virtual string OfficePhone { get; set; }
    }
}
