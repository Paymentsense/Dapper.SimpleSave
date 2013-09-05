using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class TaskDto
    {
        [DataMember]public DateTime TaskStartDateTime { get; set; }
        [DataMember]public string UserName { get; set; }
    }
}