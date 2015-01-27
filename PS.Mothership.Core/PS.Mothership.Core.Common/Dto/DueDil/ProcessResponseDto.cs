using System;
using System.Net;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums.DueDil;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    [DataContract]
    public class ProcessResponseDto
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}
