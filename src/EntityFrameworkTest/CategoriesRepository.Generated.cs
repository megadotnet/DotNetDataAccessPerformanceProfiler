using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using EntityFrameworkTest;
// This file is auto generated and will be overwritten as soon as the template is executed
// Do not modify this file...
	
namespace EntityFrameworkTest
{   
	public partial class CategoriesRepository
	{
		private IRepository<Categories> _repository {get;set;}
		public IRepository<Categories> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}
		
		public CategoriesRepository(IRepository<Categories> repository, IUnitOfWork unitOfWork)
    	{
    		Repository = repository;
			Repository.UnitOfWork = unitOfWork;
    	}
		
		public IEnumerable<Categories> All()
		{
			return Repository.All();
		}

		public void Add(Categories entity)
		{
			Repository.Add(entity);
		}
		
		public void Attach(Categories entity)
		{
		    Repository.Attach(entity);
		}
		
		public void Delete(Categories entity)
		{
			Repository.Delete(entity);
		}

		public void Save()
		{
			Repository.Save();
		}
	}
}