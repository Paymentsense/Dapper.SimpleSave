using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Enums;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IStatus
    {
        StatusType StatusType { get; set; }
        string Message { get; set; }
    }
}
