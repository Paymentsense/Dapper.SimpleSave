using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums;

namespace PS.Mothership.Core.Common.Dto
{
    // TODO: Refactor
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
        public IEnumerable<Sort> Sort { get; set; }

        [DataMember]
        public Filter Filter { get; set; }
    }
        
    /// <summary>
    ///     Represents a sort expression 
    /// </summary>
    [DataContract]
    public class Sort
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

        /// <summary>
        /// Converts to form required by Dynamic Linq e.g. "Field1 desc"
        /// </summary>
        public string ToExpression()
        {
            return Field + " " + Dir;
        }
    }

    /// <summary>
    ///     Represents a filter expression 
    /// </summary>
    [DataContract]
    public class Filter
    {
        /// <summary>
        /// Gets or sets the name of the sorted field (property). Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filtering operator. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the filtering value. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        /// <remarks>
        ///     Need to look into this as return type object not a valid type in SOAP, WCF client tool will
        ///     give error
        /// </remarks>
        [DataMember(Name = "value")]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the filtering logic. Can be set to "or" or "and". Set to <c>null</c> unless <c>Filters</c> is set.
        /// </summary>
        [DataMember(Name = "logic")]
        public string Logic { get; set; }

        /// <summary>
        /// Gets or sets the child filter expressions. Set to <c>null</c> if there are no child expressions.
        /// </summary>
        [DataMember(Name = "filters")]
        public IEnumerable<Filter> Filters { get; set; }       

        /// <summary>
        /// Get a flattened list of all child filter expressions.
        /// </summary>
        public IList<Filter> All()
        {
            var filters = new List<Filter>();

            Collect(filters);

            return filters;
        }

        private void Collect(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                foreach (Filter filter in Filters)
                {
                    filters.Add(filter);
                    if (filter != null && filter.Filters != null)                    
                        filter.Collect(filter.Filters.ToList());                     
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        #region commented, kept for reference
        ///// <summary>
        ///// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
        ///// if of object is of string type then Field2.ToLower().Contains(@2)
        ///// </summary>
        ///// <param name="filters">A list of flattened filters.</param>
        ///// <param name="linqType">Type of incoming query</param>
        //public string ToExpression(IList<Filter> filters, LinqType linqType=LinqType.Entity)
        //{
        //    if (Filters != null && Filters.Any())
        //    {
        //        return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters, linqType)).ToArray()) + ")";
        //    }

        //    int index = filters.IndexOf(this);

        //    string comparison = Operators[Operator];

        //    if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
        //    {
        //        return linqType== LinqType.Object ? String.Format("{0}.{1}.{2}(@{3})", Field, "ToLower()", comparison, index) : 
        //            String.Format("{0}.{1}(@{2})", Field, comparison, index);
        //    }

        //    return String.Format("{0} {1} @{2}", Field, comparison, index);
        //}

        //#region private method

        ///// <summary>
        /////     Mapping of filtering operators to Dynamic Linq
        ///// </summary>
        //private static readonly IDictionary<string, string> Operators = new Dictionary<string, string>
        //{
        //    {"eq", "="},
        //    {"neq", "!="},
        //    {"lt", "<"},
        //    {"lte", "<="},
        //    {"gt", ">"},
        //    {"gte", ">="},
        //    {"startswith", "StartsWith"},
        //    {"endswith", "EndsWith"},
        //    {"contains", "Contains"}
        //};

        //#endregion
        #endregion
    }
}
