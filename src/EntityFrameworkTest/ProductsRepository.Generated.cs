using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using EntityFrameworkTest;
// This file is auto generated and will be overwritten as soon as the template is executed
// Do not modify this file...
	
namespace EntityFrameworkTest
{   
	public partial class ProductsRepository
	{
		private IRepository<Products> _repository {get;set;}
		public IRepository<Products> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}
		
		public ProductsRepository(IRepository<Products> repository, IUnitOfWork unitOfWork)
    	{
    		Repository = repository;
			Repository.UnitOfWork = unitOfWork;
    	}
		
		public IEnumerable<Products> All()
		{
			return Repository.All();
		}

		public void Add(Products entity)
		{
			Repository.Add(entity);
		}
		
		public void Attach(Products entity)
		{
		    Repository.Attach(entity);
		}
		
		public void Delete(Products entity)
		{
			Repository.Delete(entity);
		}

		public void Save()
		{
			Repository.Save();
		}
	}
}