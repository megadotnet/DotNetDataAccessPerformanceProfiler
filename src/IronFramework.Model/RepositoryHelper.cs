// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryHelper.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The repository helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Model
{
	public static class RepositoryHelper
	{
		public static IRepository<T> GetRepository<T>()
		{
			return ObjectFactory.GetInstance<IRepository<T>>();
		}

        public static IUnitOfWork GetUnitOfWork()
        {
            return ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(GetDbContext());
        }
		
		public static IUnitOfWork GetUnitOfWork(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<IUnitOfWork,IObjectContext>(objectcontext);
		}		
		
	    public static IObjectContext GetDbContext()
		{
			return ObjectFactory.GetInstance<IObjectContext>();
		}	
		
		
		public static CategoryRepository GetCategoryRepository()
		{
			return ObjectFactory.GetInstance<CategoryRepository>();
		}
		
		public static CategoryRepository GetCategoryRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<CategoryRepository, IObjectContext>(objectcontext);
        }


		public static CustomerRepository GetCustomerRepository()
		{
			return ObjectFactory.GetInstance<CustomerRepository>();
		}
		
		public static CustomerRepository GetCustomerRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<CustomerRepository, IObjectContext>(objectcontext);
        }


		public static ProductRepository GetProductRepository()
		{
			return ObjectFactory.GetInstance<ProductRepository>();
		}
		
		public static ProductRepository GetProductRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<ProductRepository, IObjectContext>(objectcontext);
        }

    }
}
