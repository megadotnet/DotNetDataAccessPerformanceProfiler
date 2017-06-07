

using System.Collections.Generic;
using DG.Common;

namespace DataGenerator
{
public class CustomersRepository:IRepository<Customers>
{
   		private readonly CustomersDao _customersDao;
        public CustomersRepository()
        {
            _customersDao = new CustomersDao();
        }
        public List<Customers> GetAllBySortingAndPaged(SortDefinitions sortDefinitions, int startIndex, int pageSize)
        {
            return _customersDao.GetCustomers(sortDefinitions, startIndex, pageSize);
        }

        public List<Customers> GetAllBySorting(SortDefinitions sortDefinitions)
        {
            return _customersDao.GetCustomers(sortDefinitions, -1, 0);
        }

        public List<Customers> GetAll()
        {
            return _customersDao.GetCustomers(null, -1, 0);
        }
    	public Customers GetByKey(Customers customers)
        {
           return _customersDao.GetCustomersByKey(customers);
        }
	        public long Insert(Customers customers)
        {
           return _customersDao.Insert(customers);
        }

        public void Update(Customers customers)
        {
            _customersDao.Update(customers);
        }

        public void Delete(Customers customers)
        {
            _customersDao.Delete(customers);
        }
}
public class CategoriesRepository:IRepository<Categories>
{
   		private readonly CategoriesDao _categoriesDao;
        public CategoriesRepository()
        {
            _categoriesDao = new CategoriesDao();
        }
        public List<Categories> GetAllBySortingAndPaged(SortDefinitions sortDefinitions, int startIndex, int pageSize)
        {
            return _categoriesDao.GetCategories(sortDefinitions, startIndex, pageSize);
        }

        public List<Categories> GetAllBySorting(SortDefinitions sortDefinitions)
        {
            return _categoriesDao.GetCategories(sortDefinitions, -1, 0);
        }

        public List<Categories> GetAll()
        {
            return _categoriesDao.GetCategories(null, -1, 0);
        }
            public Categories GetById(object id)
        {
           return _categoriesDao.GetCategoriesById(id);
        }
	        public long Insert(Categories categories)
        {
           return _categoriesDao.Insert(categories);
        }

        public void Update(Categories categories)
        {
            _categoriesDao.Update(categories);
        }

        public void Delete(Categories categories)
        {
            _categoriesDao.Delete(categories);
        }
}
public class ProductsRepository:IRepository<Products>
{
   		private readonly ProductsDao _productsDao;
        public ProductsRepository()
        {
            _productsDao = new ProductsDao();
        }
        public List<Products> GetAllBySortingAndPaged(SortDefinitions sortDefinitions, int startIndex, int pageSize)
        {
            return _productsDao.GetProducts(sortDefinitions, startIndex, pageSize);
        }

        public List<Products> GetAllBySorting(SortDefinitions sortDefinitions)
        {
            return _productsDao.GetProducts(sortDefinitions, -1, 0);
        }

        public List<Products> GetAll()
        {
            return _productsDao.GetProducts(null, -1, 0);
        }
            public Products GetById(object id)
        {
           return _productsDao.GetProductsById(id);
        }
	        public long Insert(Products products)
        {
           return _productsDao.Insert(products);
        }

        public void Update(Products products)
        {
            _productsDao.Update(products);
        }

        public void Delete(Products products)
        {
            _productsDao.Delete(products);
        }
}

}