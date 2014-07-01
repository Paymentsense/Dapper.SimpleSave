using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    [DataContract]
    public class FirstData_ApplicationTerminalDto
    {
        [DataMember]
        public int TerminalTypeID { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public int NumberOfUnits { get; set; }
        [DataMember]
        public decimal Rate { get; set; }
        [DataMember]
        public bool IsGratuity { get; set; }
        [DataMember]
        public bool IsCashBack { get; set; }
        [DataMember]
        public bool IsETopUp { get; set; }
        [DataMember]
        public bool IsPreAuth { get; set; }
    }
}
