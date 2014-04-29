using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class DocumentsInfoDto
    {
        [DataMember]
        public string DocumentId { get; set; }
        [DataMember]
        public string MimeType { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
