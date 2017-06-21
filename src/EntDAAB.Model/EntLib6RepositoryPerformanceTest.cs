using DataGenerator;
using DBPerformanceTest.Core;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var customers = _customersRepository.GetByKey(new Customers { CustomerID = "10" });

                var products = _productRepository.GetById(10);

                var categories = _categoriesRepository.GetById(10);

            }, repeatTime);
        }
    }
}
