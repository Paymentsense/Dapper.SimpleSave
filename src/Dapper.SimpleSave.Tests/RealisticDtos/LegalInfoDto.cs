using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[app].[LEGAL_INFO_MST]")]
    public class LegalInfoDto
    {
        [PrimaryKey]
        public int? LegalInfoKey { get; set; }

        [ForeignKeyReference(typeof(ApplicationDetailsDto))]
        public Guid? ApplicationGuid { get; set; }

        [ManyToOne]
        [Column("MerchantLegalInfoKey")]
        public MerchantLegalInfoDto MerchantLegalInfo { get; set; }

        public string BacsName { get; set; }

        public decimal CurrentOverdraftLimit { get; set; }
    }
}
