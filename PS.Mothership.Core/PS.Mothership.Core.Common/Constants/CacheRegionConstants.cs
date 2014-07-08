using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Constants
{
    /// <summary>
    ///     This static class hold all the cache region
    ///     names. 
    ///     Easy to maintain
    /// </summary>
    public static class CacheRegionConstants
    {
        // To store ip address for remote access validation
        public const string Ipregion = "LOGIN_IP_LUT";

        // To store user manage management
        public const string UserManagement = "user_management";
    }    
}
