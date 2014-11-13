using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Caching
{
    /// <summary>
    ///     Store value and outputs 
    /// </summary>
    public class ServiceCacheData
    {
        public object Value { get; set; }
        public object[] Outputs { get; set; }
    }
}
