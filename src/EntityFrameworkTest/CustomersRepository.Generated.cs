using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using EntityFrameworkTest;
// This file is auto generated and will be overwritten as soon as the template is executed
// Do not modify this file...
	
namespace EntityFrameworkTest
{   
	public partial class CustomersRepository
	{
		private IRepository<Customers> _repository {get;set;}
		public IRepository<Customers> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}
		
		public CustomersRepository(IRepository<Customers> repository, IUnitOfWork unitOfWork)
    	{
    		Repository = repository;
			Repository.UnitOfWork = unitOfWork;
    	}
		
		public IEnumerable<Customers> All()
		{
			return Repository.All();
		}

		public void Add(Customers entity)
		{
			Repository.Add(entity);
		}
		
		public void Attach(Customers entity)
		{
		    Repository.Attach(entity);
		}
		
		public void Delete(Customers entity)
		{
			Repository.Delete(entity);
		}

		public void Save()
		{
			Repository.Save();
		}
	}
}