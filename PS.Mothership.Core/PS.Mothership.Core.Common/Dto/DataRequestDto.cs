using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class DataRequestDto
    {
        [DataMember]
        public int Page { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int End { get; set; }

        [DataMember]
        public IList<SortDescriptor> Sorts { get; set; }
    }
    
    /// <summary>
    ///     Represents declarative sorting.
    /// </summary>
    public class SortDescriptor
    {
        public SortDescriptor() { }

        public SortDescriptor(string member, ListSortDirection order) { }

        // Summary:
        //     Gets or sets the member name which will be used for sorting.
        public string Member { get; set; }
        //
        // Summary:
        //     Gets or sets the sort direction for this sort descriptor. If the value is
        //     null no sorting will be applied.
        public ListSortDirection SortDirection { get; set; }
    }
}
