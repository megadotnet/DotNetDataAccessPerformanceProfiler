// ***********************************************************************
// Assembly         : EntityFrameworkV1.Model
// Author           : PeterLiu
// Created          : 07-26-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 08-05-2014
// ***********************************************************************
// <copyright file="EF4POCOPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using DBPerformanceTest.Core;

namespace EntityFrameworkTest
{
    /// <summary>
    /// EF4POCOPerformanceTest
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class  EF4POCOPerformanceTest:IPerformanceTest
    {
        /// <summary>
        /// Fetches the single test.
        /// </summary>
        /// <param name="repeatTime">The repeat time.</param>
        /// <returns>The fetch single test.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public long FetchSingleTest(int repeatTime)
        {
            var rproductrepository = RepositoryHelper.GetProductsRepository();
            var categoryrepository = RepositoryHelper.GetCategoriesRepository(rproductrepository.Repository.UnitOfWork);
            var customrepository = RepositoryHelper.GetCustomersRepository(rproductrepository.Repository.UnitOfWork);

            return Utility.PerformanceWatch(() =>
                                                {
                                                    for (int i = 0; i < repeatTime; i++)
                                                    {
                                                        var products =
                                                            rproductrepository.Repository.Find(p => p.ProductID == 10).
                                                                ToList();
                                                        var categories =
                                                            categoryrepository.Repository.Find(c => c.CategoryID == 10).
                                                                ToList();
                                                        var cutomers =
                                                            customrepository.Repository.Find(
                                                                cut => cut.CustomerID == "10").ToList();
                                                    }
                                                });
        }

        /// <summary>
        /// Fetches all test.
        /// </summary>
        /// <param name="repeatTime">The repeat time.</param>
        /// <returns>The fetch all test.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public long FetchAllTest(int repeatTime)
        {
            var rproductrepository = RepositoryHelper.GetProductsRepository();
            var categoryrepository = RepositoryHelper.GetCategoriesRepository(rproductrepository.Repository.UnitOfWork);
            var customrepository = RepositoryHelper.GetCustomersRepository(rproductrepository.Repository.UnitOfWork);

            return Utility.PerformanceWatch(() =>
                                                {
                                                    for (int i = 0; i < repeatTime; i++)
                                                    {
                                                        var products = rproductrepository.All().ToList();
                                                        var categories = categoryrepository.All().ToList();
                                                        var cutomers = customrepository.All().ToList();
                                                    }
                                                });
        }

        /// <summary>
        /// Writes the test.
        /// </summary>
        /// <param name="repeatTime">The repeat time.</param>
        /// <returns>The write test.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public long WriteTest(int repeatTime)
        {
            var dbcontext = new TestPerformaceDBEntities();

            return Utility.PerformanceWatch(() =>
                                                {
                                                    for (int i = 0; i < repeatTime; i++)
                                                    {
                                                        CustomerCRUD(dbcontext);

                                                        var cat = new Categories
                                                                      {
                                                                          CategoryName = "Widgets",
                                                                          Description = "Widgets are the ……"
                                                                      };

                                                        var newProduct = new Products
                                                                             {
                                                                                 ProductName = "Blue Widget",
                                                                                 UnitPrice = 34.56M,
                                                                                 Categories = cat

                                                                             };

                                                        dbcontext.Products.AddObject(newProduct);
                                                        dbcontext.SaveChanges();

                                                        //Update category
                                                        cat.CategoryName = "testupdated";
                                                        dbcontext.SaveChanges();

                                                        //Update product
                                                        newProduct.UnitPrice = 15.8M;
                                                        dbcontext.SaveChanges();

                                                        //Delete Products
                                                        dbcontext.Products.DeleteObject(newProduct);
                                                        dbcontext.SaveChanges();

                                                        dbcontext.Categories.DeleteObject(cat);
                                                        dbcontext.SaveChanges();
                                                     
                                                    }
                                                });
        }

        private static void CustomerCRUD(TestPerformaceDBEntities dbcontext)
        {
            var cus = new Customers
            {
                CustomerID = "test",
                CompanyName = "company name",
                ContactName = "contact name",
                Address = "address"
            };

            dbcontext.Customers.AddObject(cus);
            dbcontext.SaveChanges();


            cus.CompanyName = "update name";
            dbcontext.SaveChanges();

            dbcontext.Customers.DeleteObject(cus);
            dbcontext.SaveChanges();
        }
    }
}