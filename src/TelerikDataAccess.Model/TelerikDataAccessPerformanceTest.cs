// ***********************************************************************
// Assembly         : TelerikDataAccess.Model
// Author           : PeterLiu
// Created          : 08-05-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 08-05-2014
// ***********************************************************************
// <copyright file="TelerikDataAccessPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DBPerformanceTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikDataAccess.Model
{
    /// <summary>
    /// Class TelerikDataAccessPerformanceTest
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class TelerikDataAccessPerformanceTest : IPerformanceTest
    {
        /// <summary>
        /// Fetches all test.
        /// </summary>
        /// <param name="repeatTime">The repeat time.</param>
        /// <returns>The fetch all test.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public long FetchAllTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
                     () =>
                     {
                         using (var dbContext = new EntitiesModel())
                         {
                             for (int i = 0; i < repeatTime; i++)
                             {

                                 var customers = dbContext.Customers.ToList();
                                 var products = dbContext.Products.ToList();
                                 var category = dbContext.Categories.ToList();

                             }
                         }

                     });
        }

        /// <summary>
        /// Fetches the single test.
        /// </summary>
        /// <param name="repeatTime">The repeat time.</param>
        /// <returns>The fetch single test.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public long FetchSingleTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
                     () =>
                     {
                         using (var dbContext = new EntitiesModel())
                         {
                             for (int i = 0; i < repeatTime; i++)
                             {

                                 var customers = dbContext.Customers.FirstOrDefault();
                                 var products = dbContext.Products.FirstOrDefault();
                                 var category = dbContext.Categories.FirstOrDefault();

                             }
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
            return Utility.PerformanceWatch(
                    () =>
                    {
                        using (var dbContext = new EntitiesModel())
                        {

                            for (int i = 0; i < repeatTime; i++)
                            {

                                CustomerCRUD(dbContext);

                                var category = new Category()
                                {
                                    CategoryName = "mycategory",
                                    Description = "fortest"
                                };

                                //add category
                                dbContext.Add(category);
                                dbContext.SaveChanges();
                                //update category
                                var categoryupdate = dbContext.Categories.Where(c => c.CategoryID == category.CategoryID).FirstOrDefault();
                                categoryupdate.CategoryName = "newName";
                                dbContext.SaveChanges();

                                var product = new Product()
                                {
                                    ProductName = "productname",
                                    QuantityPerUnit = "st",
                                    UnitPrice = 12,
                                    SupplierID = 1,
                                    CategoryID = category.CategoryID
                                };
                                //add product
                                dbContext.Add(product);
                                dbContext.SaveChanges();
                                //update product
                                var productforupdate = dbContext.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
                                productforupdate.ProductName = "productupdatename";
                                dbContext.SaveChanges();

                                //delete product
                                dbContext.Delete(product);
                                dbContext.SaveChanges();
                                //delete category
                                dbContext.Delete(category);
                                dbContext.SaveChanges();


                            }
                        }

                    });
        }

        /// <summary>
        /// Customers the CRUD.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void CustomerCRUD(EntitiesModel dbContext)
        {
            Customer newCustomer = new Customer();
            newCustomer.ContactName = "New Customer";
            newCustomer.CustomerID = "9912";

            dbContext.Add(newCustomer);
            dbContext.SaveChanges();

            Customer firstCustomer = dbContext.Customers.Where(c => c.CustomerID == newCustomer.CustomerID).FirstOrDefault();
            firstCustomer.ContactName = firstCustomer.ContactName + "Updated";
            // Commit changes to the database. 
            dbContext.SaveChanges();

            // Delete the 'New Customer' from the database. 
            dbContext.Delete(newCustomer);
            // Commit changes to the database. 
            dbContext.SaveChanges();
        }
    }
}
