using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.DynamicRequest
{
    /// <summary>
    ///     This is the mapping of data source options
    ///     send from the js grid
    /// </summary>
    /// <remarks>
    ///     The naming conventions from javaScript
    ///     are given the as a data memeber name
    ///     for easy mapping    
    /// </remarks>    
    [DataContract]
    public class DataRequestDto
    {
        [DataMember]
        public int Page { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int Take { get; set; }

        [DataMember]
        public int Skip { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int End { get; set; }

        [DataMember]
        public ICollection<SortDto> Sort { get; set; }

        [DataMember]
        public FilterDto Filter { get; set; }
    }
}
