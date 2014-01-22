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
        Create,
        Clear,
        Remove
    }
}
