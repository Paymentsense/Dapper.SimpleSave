using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[ACQUIRING_OFFER_TRN]")]
    public class AcquiringOfferTrnDao
    {
        [PrimaryKey]
        public int? AcquiringOfferKey { get; set; }

        [ForeignKeyReference(typeof(OfferDto))]
        public Guid? OfferGuid { get; set; }

        public int CreditCardTurnoverMonthly { get; set; }
        public int DebitCardTransactionMonthly { get; set; }
        public int CardTransactionPerAnnum { get; set; }
        public int DebitCardTransactionPercentage { get; set; }

        [ManyToOne]
        [Column("TypeOfTransactionKey")]
        public TypeOfTransactionLutDao TypeOfTransaction { get; set; }
    }
}
