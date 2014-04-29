using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class LibraryDocumentIdDto
    {
        [DataMember]
        public List<DocumentLibraryItemDto> LibraryDocumentList { get; set; }
    }
}
