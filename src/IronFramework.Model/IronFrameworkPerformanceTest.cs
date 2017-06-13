// ***********************************************************************
// Assembly         : Linq2dbPerformanceTest.Model
// Author           : PeterLiu
// Created          : 06-13-2017
//
// Last Modified By : PeterLiu
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="IronFrameworkPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace IronFramework.Model
{
    using DBPerformanceTest.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IronFrameworkPerformanceTest
    /// </summary>
    public class IronFrameworkPerformanceTest : IPerformanceTest
    {
        private readonly ProductRepository productRepository= RepositoryHelper.GetProductRepository();
        private readonly CategoryRepository categoryRepository = RepositoryHelper.GetCategoryRepository();
        private readonly CustomerRepository customerRepository = RepositoryHelper.GetCustomerRepository();


        /// <summary>
        /// FetchAllTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchAllTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
     () =>
     {
         for (int i = 0; i < repeatTime; i++)
         {
             var products = productRepository.All().ToList();
             var categories = categoryRepository.All().ToList();
             var customers=customerRepository.All().ToList();
         }
     });

        }

        /// <summary>
        /// FetchSingleTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchSingleTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
() =>
{
    for (int i = 0; i < repeatTime; i++)
    {
        var product=productRepository.Repository.Find(p => p.ProductID == 10).FirstOrDefault();
        var category = categoryRepository.Repository.Find(c => c.CategoryID == 10).FirstOrDefault();
        var customer = customerRepository.Repository.Find(cu => cu.CustomerID == "10").FirstOrDefault();
    }
});
        }

        /// <summary>
        /// WriteTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long WriteTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
     () =>
     {
         for (int i = 0; i < repeatTime; i++)
         {
             //Insert
             var customer = new Customer
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
                 CustomerID = "101" + new Random().Next(2, 100)
             };

             customerRepository.Add(customer);
             customerRepository.Save();

             var cat = new Category { CategoryName = "Widgets234", Description = "Widgets are 43the ……" };
             var newProduct = new Product { ProductName = "Blue Widget234", UnitPrice = 35.56M, Category = cat };

             //categoryRepository.Add(cat);
             //categoryRepository.Save();
             //Insert with parent and child record to database
             productRepository.Add(newProduct);
             productRepository.Save();

             //Update
             var productfromDb = productRepository.Repository.Find(p => p.ProductID == newProduct.ProductID).FirstOrDefault();
             productfromDb.ProductName = "changename";
             productRepository.Save();

             var customerfromdb = customerRepository.Repository.Find(cu => cu.CustomerID == customer.CustomerID).FirstOrDefault();
             customerfromdb.ContactName = "customerfromdb";
             customerRepository.Save();

             var categoryFromDb = categoryRepository.Repository.Find(c => c.CategoryID == productfromDb.CategoryID).FirstOrDefault();
             //categoryFromDb.CategoryName = "changcategoryename";
             //categoryRepository.Save();

             //delete
             productRepository.Delete(productfromDb);
             categoryRepository.Delete(categoryFromDb);
             customerRepository.Delete(customerfromdb);
         }
     });
        }
    }
}
