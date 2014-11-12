using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.DynamicRequest
{
    /// <summary>
    ///     Represents a sort expression 
    /// </summary>
    [DataContract(Name = "sort")]    
    public class SortDto
    {
        /// <summary>
        /// Gets or sets the name of the sorted field (property).
        /// </summary>
        [DataMember(Name = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the sort direction. Should be either "asc" or "desc".
        /// </summary>
        [DataMember(Name = "dir")]
        public string Dir { get; set; }

        //
        // Summary:
        //     Gets or sets the sort direction for this sort descriptor. If the value is
        //     null no sorting will be applied.
        public ListSortDirection SortDirection
        {
            get
            {
                return string.Compare(Dir, "asc", StringComparison.OrdinalIgnoreCase) == 0
                    ? ListSortDirection.Ascending
                    : ListSortDirection.Descending;
            }
        }        
    }   
}
