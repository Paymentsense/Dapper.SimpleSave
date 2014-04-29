using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Log4NetJsonFormatter.Entities
{
    public class LoggingEntity
    {
        public string Date { get; set; }
        public string Message { get; set; }
        public string ApplicationName { get; set; }
        public string Thread { get; set; }
        public string ErrorLevel { get; set; }
        public string AssemblyName { get; set; }
    }
}
