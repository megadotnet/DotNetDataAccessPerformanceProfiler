// ***********************************************************************
// Assembly         : Linq2dbPerformanceTest.Model
// Author           : PeterLiu
// Created          : 06-01-2017
//
// Last Modified By : PeterLiu
// Last Modified On : 06-01-2017
// ***********************************************************************
// <copyright file="Linq2dbPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Linq2db.Model
{
    using DataModels;
    using DBPerformanceTest.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LinqToDB;
    using LinqToDB.Data;
    using LinqToDB.DataProvider.SqlServer;
    using LinqToDB.Linq;
    using LinqToDB.Mapping;


    /// <summary>
    /// Linq2dbPerformanceTest
    /// </summary>
    public class Linq2dbPerformanceTest : IPerformanceTest
    {
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

                    using (var db = new TestPerformaceDBDB())
                    {
                        var categories=db.Categories.ToList();
                        var customer = db.Products.ToList();
                        var product= db.Customers.ToList();
                    }

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

               using (var db = new TestPerformaceDBDB())
               {
                      var categories =db.Categories.Find(10);
                      var customer = db.Products.Find(10);
                      var product = db.Customers.Find("10");
                 }

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

            using (var db = new TestPerformaceDBDB())
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
                    CustomerID = "9011"
                };

                var custmId = db.InsertWithIdentity(customer);


                var cat = new Category { CategoryName = "Widgets234", Description = "Widgets are 43the ……" };

                var newProduct = new Product { ProductName = "Blue Widget234", UnitPrice = 35.56M, Category = cat };

                var catgoriesId = db.InsertWithIdentity(cat);
                var productionId = db.InsertWithIdentity(newProduct);

                //Update
                db.Products
                  .Where(p => p.ProductID == 10)
                  .Set(p => p.ProductName, "test prod")
                  .Update();

                db.Categories
        .Where(p => p.CategoryID == 10)
        .Set(p => p.CategoryName, "test cat")
        .Update();

                //Delete
                db.Delete(customer);
                db.Delete(newProduct);
                db.Delete(cat);


            }

        }
    });
        }
    }
}
