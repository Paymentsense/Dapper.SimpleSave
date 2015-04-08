using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AddOnServiceItemDto
    {
        [DataMember]
        public int AddOnServiceItemKey { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }


    }
}
