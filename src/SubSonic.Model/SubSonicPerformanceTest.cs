// ***********************************************************************
// Assembly         : SubSonic.Model
// Author           : PeterLiu
// Created          : 08-03-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 08-04-2014
// ***********************************************************************
// <copyright file="SubSonicPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DBPerformanceTest.Core;
using SubSonic.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSonic.Model
{
    /// <summary>
    /// Class SubSonicPerformanceTest
    /// </summary>
    /// <see cref="http://programmingfuel.com/subsonic-30-a-closer-look-at-activerecord" />
    ///   <seealso cref="https://github.com/subsonic/SubSonic-3.0/blob/master/SubSonic.Tests/SimpleQuery/"/>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class SubSonicPerformanceTest : IPerformanceTest
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
                    for (int i = 0; i < repeatTime; i++)
                    {
                        var product = new Select().From<Product>();
                        var customer = new Select().From<Customer>();
                        var category = new Select().From<Category>();
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
                          for (int i = 0; i < repeatTime; i++)
                          {
                              var p = new Select().From<Product>().Where("ProductID").IsEqualTo(10).ExecuteSingle<Product>();

                              var customer = new Select().From<Customer>().Where("CustomerID").IsEqualTo("10").ExecuteSingle<Customer>();

                              var category = new Select().From<Category>().Where("CategoryID").IsEqualTo(10).ExecuteSingle<Category>();
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
            var dbcontext3 = new TestPerformaceDBDB();
            return Utility.PerformanceWatch(
                   () =>
                   {
                       for (int i = 0; i < repeatTime; i++)
                       {

                           CustomerModelCRUD(dbcontext3, i);

                           var category = new Category()
                           {
                               CategoryName = "AirLine",
                               Description = "For Air"
                           };

                          category.CategoryID= dbcontext3.Insert.Into<Category>(c => c.CategoryName, c => c.Description).Values(category.CategoryName,category.Description).Execute();

                          dbcontext3.Update<Category>().Set("CategoryName").EqualTo("testupdate").Where<Category>(x => x.CategoryID == category.CategoryID).Execute();

                           var product = new Product()
                           {
                               ProductName = "testproduct1",
                               UnitPrice = 10,
                               QuantityPerUnit = "tt",
                               SupplierID = 3,
                                CategoryID=category.CategoryID

                           };

                           product.ProductID = dbcontext3.Insert.Into<Product>(p => p.ProductName, p => p.UnitPrice, p => p.QuantityPerUnit, p => p.SupplierID)
                               .Values(product.ProductName, product.UnitPrice, product.QuantityPerUnit, product.SupplierID).Execute();

                           dbcontext3.Update<Product>().Set("ProductName").EqualTo("updateproductname").Where<Product>(p => p.ProductID == product.ProductID).Execute();

                           dbcontext3.Delete<Category>(x => x.CategoryID == category.CategoryID).Execute();

                           dbcontext3.Delete<Product>(x => x.ProductID == product.ProductID).Execute();

                       }
                   });
        }

        /// <summary>
        /// Customers the model CRUD.
        /// </summary>
        /// <param name="dbcontext3">The dbcontext3.</param>
        /// <param name="i">The i.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void CustomerModelCRUD(TestPerformaceDBDB dbcontext3, int i)
        {
            var c1 = new Customer();
            c1.CompanyName = "company";
            c1.CustomerID = "T" + i;

            //insert
            dbcontext3.Insert.Into<Customer>(c => c.CustomerID, c => c.CompanyName).Values(c1.CustomerID, c1.CompanyName).Execute();
            //update
            dbcontext3.Update<Customer>().Set("CompanyName").EqualTo("test").Where<Customer>(x => x.CustomerID == c1.CustomerID).Execute();
            //delete
            dbcontext3.Delete<Customer>(x => x.CustomerID == c1.CustomerID).Execute();
        }
    }

}
