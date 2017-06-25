using DataGenerator;
using DBPerformanceTest.Core;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DBPerformanceTest.Core;

namespace EntDAAB.Model
{
    /// <summary>
    /// EntLib6RepositoryPerformanceTest
    /// </summary>
    /// <see cref="https://msdn.microsoft.com/en-us/library/ff664431(v=pandp.50).aspx"/>
    public class EntLib6RepositoryPerformanceTest : IPerformanceTest
    {
        /// <summary>
        /// Databases
        /// </summary>
        private static CustomersRepository _customersRepository = new CustomersRepository();
        private static ProductsRepository _productRepository = new ProductsRepository();
        private static CategoriesRepository _categoriesRepository = new CategoriesRepository();

        /// <summary>
        /// EntLibDAABPerformanceTest
        /// </summary>
        static EntLib6RepositoryPerformanceTest()
        {
            //http://codepattern.net/Blog/post/Database-provider-factory-not-set-for-the-static-DatabaseFactory
            //https://msdn.microsoft.com/en-us/library/dn440726(v=pandp.60).aspx
            //if EntLibDAABPerformanceTest class has been load first, we do not need execute it.
            //DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
        }

        /// <summary>
        /// FetchAllTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchAllTest(int repeatTime)
        {
            return Utility.PerformanceWatchWithTimes(() =>
            {
                var customers = _customersRepository.GetAll();
                var products = _productRepository.GetAll();
                var categories = _categoriesRepository.GetAll();

            }, repeatTime);

        }

        /// <summary>
        /// FetchSingleTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchSingleTest(int repeatTime)
        {
            return Utility.PerformanceWatchWithTimes(() =>
            {
                var customers = _customersRepository.GetByKey(new Customers { CustomerID = "10" });

                var products = _productRepository.GetById(10);

                var categories = _categoriesRepository.GetById(10);

            }, repeatTime);
        }



        /// <summary>
        /// WriteTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long WriteTest(int repeatTime)
        {
            return Utility.PerformanceWatchWithTimes(() =>
            {
                //Insert customer
                var customer = new Customers
                {
                    CompanyName = "Newcvompanyname",
                    ContactName = "ccc",
                    Address = "asdcadsdws",
                    ContactTitle = "adsdf",
                    City = "ku2na",
                    Country = "chi2na",
                    Phone = "231",
                    PostalCode = "234",
                    Region = "ASIA",
                    CustomerID = new RNGCryptoServiceProvider().GetNextInt32(51323).ToString()
                };
        
                _customersRepository.Insert(customer);

                //insert category
                var cat = new Categories { CategoryName = "Widgetdss234"
                    , Description = "Widgetss are 43the ……", Picture=new byte[] { 1,3} };
                cat.CategoryID=Convert.ToInt32(_categoriesRepository.Insert(cat));

                //update Category
                cat.CategoryName = "Namehaschange";
                _categoriesRepository.Update(cat);

                //insert product
                var newProduct = new Products { ProductName = "Blue Widget234", UnitPrice = 35.56M, CategoryID = cat.CategoryID };
                newProduct.ProductID=Convert.ToInt32(_productRepository.Insert(newProduct));

                //update product
                newProduct.ProductName = "productchange1";
                _productRepository.Update(newProduct);

                //Delete them
                _productRepository.Delete(newProduct);
                _categoriesRepository.Delete(cat);

            }, repeatTime);
        }
    }
}
