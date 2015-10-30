using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[OPPORTUNITY_MST]")]
    public class OpportunityDto
    {
        [PrimaryKey]
        public Guid? OpportunityGuid { get; set; }

        [ForeignKeyReference(typeof(LocationDto))]
        public Guid? LocationGuid { get; set; }

        [SimpleSaveIgnore]
        public LocationDto Location { get; set; }
        
        public Guid? MerchantGuid { get; set; }

        public Guid? PartnerGuid { get; set; }

        public string AcquirerLocationMID { get; set; }

        [OneToOne]
        [Column("CurrentOfferGuid")]
        [SimpleSaveIgnore]
        public OfferDto CurrentOffer { get; set; }

    }
}
