using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    /// <summary>
    ///     This is the mapping of kendo data source options
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
    /// Represents a sort expression of Kendo DataSource.
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
    /// Represents a filter expression of Kendo DataSource.
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
        /// Mapping of Kendo DataSource filtering operators to Dynamic Linq
        /// </summary>
        private static readonly IDictionary<string, string> Operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"startswith", "StartsWith"},
            {"endswith", "EndsWith"},
            {"contains", "Contains"}
        };

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

                    filter.Collect(filters);
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        /// <summary>
        /// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
        /// </summary>
        /// <param name="filters">A list of flattened filters.</param>
        public string ToExpression(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(this);

            string comparison = Operators[Operator];

            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
            {
                return String.Format("{0}.{1}(@{2})", Field, comparison, index);
            }

            return String.Format("{0} {1} @{2}", Field, comparison, index);
        }
    }
}
