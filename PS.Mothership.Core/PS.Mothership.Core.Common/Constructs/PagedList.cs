using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Extension;

namespace PS.Mothership.Core.Common.Constructs
{
    public interface IPagedList<T>
    {
        [DataMember]
        int CurrentPage { get; }

        [DataMember]
        int ItemsPerPage { get; }

        [DataMember]
        bool HasPreviousPage { get; }

        [DataMember]
        bool HasNextPage { get; }

        [DataMember]
        int TotalPages { get; }

        [DataMember]
        int TotalItems { get; }
    }

    /// <summary>
    /// A generic Paged List
    /// </summary>
    /// <typeparam name="T">The type of item this list holds</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="source">The source list of elements containing the elements for the current page.</param>
        /// <param name="currentPage">The current page number (1 based).</param>
        /// <param name="itemsPerPage">Size of a page (number of items per page).</param>
        /// <param name="totalItems">Total Item Count</param>
        public PagedList(IEnumerable<T> source, int totalItems, int currentPage=1, int itemsPerPage=10)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage < 1 ? 1 : itemsPerPage;
            CurrentPage = Math.Min(Math.Max(1, currentPage), TotalPages);
            AddRange(source.ToList());
        }

        [DataMember]
        public int CurrentPage { get; private set; }

        [DataMember]
        public int ItemsPerPage { get; private set; }

        [DataMember]
        public bool HasPreviousPage { get { return (CurrentPage > 1); } }

        [DataMember]
        public bool HasNextPage { get { return (CurrentPage * ItemsPerPage) < TotalItems; } }

        [DataMember]    
        public int TotalPages { get { return (int)Math.Ceiling((double)TotalItems / ItemsPerPage); } }

        [DataMember]
        public int TotalItems { get; private set; }

        public static PagedList<T> Empty()
        {
            return new PagedList<T>(new List<T>(), 1, 1, 0);
        }

        public static explicit operator PagedList<T>(Collection<T> target)
        {
            if (target.GetType() == typeof(PagedList<T>))
                return (PagedList<T>)target;
            var totalItems = target.Count();
            return target.ToPagedList(totalItems);

        }

       
    }

}