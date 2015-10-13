namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].COUNTY_LUT")]
    [ReferenceData]
    public class CountyDto
    {
        [PrimaryKey]
        public int? CountyKey { get; set; }

        public string CountyName { get; set; }

        [ManyToOne]
        public GenCountryEnum CountryKey { get; set; }

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Local
        private int DapperEnumHack_CountryKey
        {
            set { CountryKey = (GenCountryEnum) value; }
        }
    }
}
