using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Constructs
{
    public struct RegexValidation
    {
        public string Regex { get; set; }
        public string RegexJavaScript { get; set; }
        public string ErrorMessage { get; set; }
    }
}
