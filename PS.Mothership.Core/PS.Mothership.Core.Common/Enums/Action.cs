using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Enums
{
    public enum Action
    {
        Add=0,
        Delete,
        Update
    }

    /// <summary>
    ///     Manage Region
    /// </summary>
    public enum RegionAction
    {
        None,
        DoCreateIfNotExists,
        Clear,
        //Remove // for now lets disable this function, as the developer would be bit confused between clear and remove
    }
}
