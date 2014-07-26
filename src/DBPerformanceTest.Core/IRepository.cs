// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Megadotnet">
//   IRepository
// </copyright>
// <summary>
//   The i repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DBPerformanceTest.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The i repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T>
        where T : class
    {
        #region Public Methods

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TKey">
        /// </typeparam>
        /// <returns>
        /// </returns>
        T GetById<TKey>(TKey id);

        /// <summary>
        /// The query.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Remove(T entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(T entity);

        #endregion
    }
}