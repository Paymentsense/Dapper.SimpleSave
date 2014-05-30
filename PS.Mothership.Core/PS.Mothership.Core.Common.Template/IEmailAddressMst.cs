using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Template
{
    public interface IEmailAddressMst
    {
        Guid EmailAddressGUID { get; set; }
        string EmailAddress { get; set; }
        long ReasonKey { get; set; }
        DateTimeOffset UpdateDate { get; set; }
        Guid UpdateSessionGUID { get; set; }
    }
}
