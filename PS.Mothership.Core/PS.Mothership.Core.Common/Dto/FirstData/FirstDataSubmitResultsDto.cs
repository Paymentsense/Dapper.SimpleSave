using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstDataSubmitResultsDto
    {
        public string RefID { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
