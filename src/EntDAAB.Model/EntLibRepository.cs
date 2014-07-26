// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntLibRepository.cs" company="Megadotnet">
//   EntLibRepository
// </copyright>
// <summary>
//   EntLibRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EntDAAB.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using DBPerformanceTest.Core;
    using DBPerformanceTest.Core.Model;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// EntLibRepository
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    /// TODO: plan write a simple object convert to sql statement by reflection
    public abstract class EntLibRepository<T> : IRepository<T>
        where T : class, new()
    {
        #region Constants and Fields

        /// <summary>
        /// The _db.
        /// </summary>
        private static readonly Database _db = DatabaseFactory.CreateDatabase("TestDB");

        #endregion

        #region Implemented Interfaces

        #region IRepository<T>

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

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
        public T GetById<TKey>(TKey id)
        {
            IRowMapper<T> mapper = MapBuilder<T>.BuildAllProperties();

            // Use a custom parameter mapper and the default output mappings
            IParameterMapper paramMapper = new MyParameterMapper();
            DataAccessor<T> accessor = _db.CreateSqlStringAccessor(typeof(T).ToString(), paramMapper, mapper);
            IEnumerable<T> genericDataCollection = accessor.Execute(id);

            return genericDataCollection.First();
        }

        /// <summary>
        /// The query.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// The product repository.
    /// </summary>
    public class ProductRepository : EntLibRepository<Product>
    {
    }
}