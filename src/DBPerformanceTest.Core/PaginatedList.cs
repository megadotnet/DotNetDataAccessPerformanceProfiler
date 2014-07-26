// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginatedList.cs" company="Megadotnet">
//   PaginatedList
// </copyright>
// <summary>
//   PaginatedList
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DBPerformanceTest.Core
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// PaginatedList
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///    public PaginatedList<T> FindList(int? page, int pageSize, Expression<Func<T, bool>> predicate)
    ///    {
    ///        return new PaginatedList<T>(Query(predicate), page, pageSize);
    ///    }
    /// 
    /// ]]>
    /// </code>
    /// </example>
    /// <typeparam name="T">
    /// </typeparam>
    public class PaginatedList<T> : List<T>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PaginatedList(IQueryable<T> source, int? pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex ?? 1;
            this.PageSize = pageSize;
            this.TotalCount = source.Count();
            this.TotalPages = ((this.TotalCount - 1) / this.PageSize) + 1;

            this.AddRange(source.Skip((this.PageIndex - 1) * this.PageSize).Take(this.PageSize));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether HasNextPage.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return this.PageIndex < this.TotalPages;
            }
        }

        /// <summary>
        /// Gets a value indicating whether HasPreviousPage.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return this.PageIndex > 1;
            }
        }

        /// <summary>
        /// Gets PageIndex.
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets PageSize.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets TotalCount.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets TotalPages.
        /// </summary>
        public int TotalPages { get; private set; }

        #endregion
    }
}