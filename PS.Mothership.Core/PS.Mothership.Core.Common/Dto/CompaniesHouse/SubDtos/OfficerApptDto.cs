namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerApptDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        //TODO Enum
        public string CompanyStatus { get; set; }
        public string AppointmentStatus { get; set; }
        //TODO Enum
        public string AppointmentType { get; set; }
        public string AppointmentDatePrefix { get; set; }
        public string AppointmentDate { get; set; }
        public string ResignationDate { get; set; }
        public string Occupation { get; set; }
    }
}
