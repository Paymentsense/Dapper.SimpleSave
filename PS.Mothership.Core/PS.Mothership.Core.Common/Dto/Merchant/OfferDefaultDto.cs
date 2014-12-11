using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class OfferDefaultDto
    {
        public Guid OfferDefaultsTrnGUID { get; set; }

        public GenCountryEnum CountryKey { get; set; }

        public int TypeOfTransactionKey { get; set; }

        public int CustomerTypeKey { get; set; }

        public int CalculatorVersionKey { get; set; }

        public int FieldKey { get; set; }

        public int FieldItemKey { get; set; }
    }
}
