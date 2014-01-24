using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class SearchDto
    {
        [DataMember]
        public string SearchPhrase { get; set; }
        [DataMember]
        public DataRequestDto DataRequest { get; set; }
    }
}
