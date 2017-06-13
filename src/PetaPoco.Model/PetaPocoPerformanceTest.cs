// ***********************************************************************
// Assembly         : Linq2dbPerformanceTest.Model
// Author           : PeterLiu
// Created          : 06-02-2017
//
// Last Modified By : PeterLiu
// Last Modified On : 06-02-2017
// ***********************************************************************
// <copyright file="PetaPocoPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
namespace PetaPoco.Model
{
    using DBPerformanceTest.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestPerformaceDBConnection;


    /// <summary>
    /// PetaPocoPerformanceTest
    /// </summary>
    public class PetaPocoPerformanceTest : IPerformanceTest
    {
        private TestPerformaceDBConnectionDB db = new TestPerformaceDBConnectionDB();

        /// <summary>
        /// FetchAllTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <seealso cref="https://github.com/CollaboratingPlatypus/PetaPoco/wiki/Quick-Start"/>
        /// <returns></returns>
        public long FetchAllTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
              () =>
          {
           
              for (int i = 0; i < repeatTime; i++)
              {
                  var customers = db.Query<Customer>("select * from Customers").ToList();
                  var product = db.Query<Product>("select * from Products").ToList();
                  var categories = db.Query<Category>("select * from Categories").ToList();
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
            var customers = db.Query<Customer>("select * from Customers where CustomerID = '10'").FirstOrDefault();
            var product = db.Query<Product>("select * from Products where ProductID = 10").FirstOrDefault();
            var categories = db.Query<Category>("select * from Categories where CategoryID = 10").FirstOrDefault();
        }

    });
        }

        /// <summary>
        /// WriteTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        /// <seealso cref="https://github.com/CollaboratingPlatypus/PetaPoco/wiki/Inserting"/>
        public long WriteTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
() =>
{
    for (int i = 0; i < repeatTime; i++)
    {
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
            CustomerID = "210"+ new Random().Next(0,100)
        };

        // Tell PetaPoco to insert it
        var customerid = db.Insert(customer);
        customer.Address = "AddressChanged";
        customer.ContactTitle = "ProductManager";

        // Tell PetaPoco to update the DB
        db.Update(customer);

        var cat = new Category { CategoryName = "Widgets234", Description = "Widgets are 43the ……" };
        var catid = db.Insert(cat);
        int categoryId = Convert.ToInt32(catid);
        cat.CategoryID = categoryId;

        var newProduct = new Product { ProductName = "Blue Widget234", UnitPrice = 35.56M, CategoryID = categoryId };
        var productid = db.Insert(newProduct);
        newProduct.ProductID = Convert.ToInt32(productid);

        //delete all of them
        db.Delete(customer);
        db.Delete(newProduct);
        db.Delete(cat);
    }

});
        }
    }
}
