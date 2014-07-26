using EntityFrameworkTest;

namespace EntityFrameworkTest
{
	public static class RepositoryHelper
	{
		public static IRepository<T> GetRepository<T>()
		{
			return ObjectFactory.GetInstance<IRepository<T>>();
		}

		public static IUnitOfWork GetUnitOfWork()
		{
			return ObjectFactory.GetInstance<IUnitOfWork>();
		}		
		
		public static CategoriesRepository GetCategoriesRepository()
		{
			return ObjectFactory.GetInstance<CategoriesRepository>();
		}

		public static CategoriesRepository GetCategoriesRepository(IUnitOfWork unitOfWork)
		{
			return new CategoriesRepository(GetRepository<Categories>(), unitOfWork);
		}		
		
		public static CategoriesRepository GetCategoriesRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<CategoriesRepository, IObjectContext>(objectcontext);
        }

        public static CategoriesRepository GetCategoriesRepository(IUnitOfWork unitOfWork, IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<CategoriesRepository, IObjectContext, IUnitOfWork>(objectcontext, unitOfWork);
        }	

		public static CustomersRepository GetCustomersRepository()
		{
			return ObjectFactory.GetInstance<CustomersRepository>();
		}

		public static CustomersRepository GetCustomersRepository(IUnitOfWork unitOfWork)
		{
			return new CustomersRepository(GetRepository<Customers>(), unitOfWork);
		}		
		
		public static CustomersRepository GetCustomersRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<CustomersRepository, IObjectContext>(objectcontext);
        }

        public static CustomersRepository GetCustomersRepository(IUnitOfWork unitOfWork, IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<CustomersRepository, IObjectContext, IUnitOfWork>(objectcontext, unitOfWork);
        }	

		public static ProductsRepository GetProductsRepository()
		{
			return ObjectFactory.GetInstance<ProductsRepository>();
		}

		public static ProductsRepository GetProductsRepository(IUnitOfWork unitOfWork)
		{
			return new ProductsRepository(GetRepository<Products>(), unitOfWork);
		}		
		
		public static ProductsRepository GetProductsRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<ProductsRepository, IObjectContext>(objectcontext);
        }

        public static ProductsRepository GetProductsRepository(IUnitOfWork unitOfWork, IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<ProductsRepository, IObjectContext, IUnitOfWork>(objectcontext, unitOfWork);
        }	
    }
}
