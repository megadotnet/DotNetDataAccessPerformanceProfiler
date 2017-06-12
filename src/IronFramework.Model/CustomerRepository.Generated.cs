// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerRepository.cs" company="Megadotnet">
// Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The Customer repository.
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace IronFramework.Model
{  
    using System;
    using System.Linq;
    using System.Linq.Expressions;
	using System.Threading.Tasks;
    using System.Collections.Generic;

    using IronFramework.Utility.UI;
 
	public partial class CustomerRepository
	{
		private IRepository<Customer> _repository {get;set;}
		public IRepository<Customer> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}
		
		public CustomerRepository(IRepository<Customer> repository)
    	{
    		Repository = repository;
    	}
		
		/// <summary>
        /// Alls enties 
        /// </summary>
        /// <returns>Alls enties</returns>
		public IEnumerable<Customer> All()
		{
			return Repository.All();
		}

		 /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Add(Customer entity)
		{
			Repository.Add(entity);
		}
		
		 /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Attach(Customer entity)
		{
		    Repository.Attach(entity);
		}
		
		/// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Delete(Customer entity)
		{
			Repository.Delete(entity);
		}

		/// <summary>
        /// Saves this instance.
        /// </summary>
		public void Save()
		{
			Repository.Save();
		}

		/// <summary>
        /// SaveAsync
        /// </summary>
        public async Task<int> SaveAsync()
        {
            return await Repository.SaveAsync();
        }
	}
}