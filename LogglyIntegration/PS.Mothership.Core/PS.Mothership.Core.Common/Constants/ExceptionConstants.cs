using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Constants
{
    public class ExceptionConstants
    {
        public const string EndpointNotFoundErrorMessage =
            "This exception occurs when Wcf Service server is either not started or the endpoints defined in the web.config " +
            "file are not pointing to the correct address.";

        public const string CommonExceptionMessage = @" <p> Something went wrong... Somewhere...<br/><br/>
                Please try refreshing the page to resolve the issue.<br/><br/>
                If this problem persists contact IT Support for assistance quoting the <strong>Unique Key: $$UniqueKey </strong>.<br/></p>";
    }
}
