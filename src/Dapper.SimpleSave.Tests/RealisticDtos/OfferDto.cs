using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[OFFER_TRN]")]
    public class OfferDto
    {
        public OfferDto()
        {
            Equipment = new List<EquipmentOfferTrnDao>();
        }

        [PrimaryKey]
        public Guid? OfferGuid { get; set; }

        [ManyToOne]
        [Column("GatewayOfferGuid")]
        [ForeignKeyReference(typeof(GatewayOfferDto))]
        public GatewayOfferDto GatewayOffer { get; set; }

        [ForeignKeyReference(typeof(OpportunityDto))]
        public Guid? OpportunityGuid { get; set; }

        public string OfferReference { get; set; }

        [OneToOne("OfferGuid")]
        public AcquiringOfferTrnDao AcquiringOffer { get; set; }

        [OneToMany]
        public IList<EquipmentOfferTrnDao> Equipment { get; set; }
    }
}
