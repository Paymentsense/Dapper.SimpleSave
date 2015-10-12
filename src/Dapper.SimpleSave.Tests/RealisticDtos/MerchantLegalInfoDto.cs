using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[cust].[MERCHANT_LEGAL_INFO_TRN]")]
    public class MerchantLegalInfoDto
    {
        [PrimaryKey]
        public int? MerchantLegalInfoKey { get; set; }

        public Guid? MerchantGuid { get; set; }

        public string RegisteredName { get; set; }
    }
}
