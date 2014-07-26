// ***********************************************************************
// Assembly         : Simple.Data.Model
// Author           : PeterLiu
// Created          : 07-26-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 07-26-2014
// ***********************************************************************
// <copyright file="SimpleDataPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DBPerformanceTest.Core;
using DBPerformanceTest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Data.Model
{
    /// <summary>
    /// Class SimpleDataPerformanceTest
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class SimpleDataPerformanceTest : IPerformanceTest
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
                       var categories = Database.Open().Categories.All();
                       var products = Database.Open().Products.All();
                       var customers = Database.Open().Customers.All();
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
             var categories = Database.Open().Categories.FindAllByCategoryID(1);
             var customer = Database.Open().Customers.FindAllByCustomerID(1);
             var product = Database.Open().Products.FindAllByProductID(1);

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
            var _db = Database.Open();
            return Utility.PerformanceWatch(
       () =>
       {
           for (int i = 0; i < repeatTime; i++)
           {
               //insert
               var category = new Category {  CategoryName = "Shipment",  Description = "for test" };
               var newCategory = _db.Categories.Insert(category);

               var product = new Product { ProductName = "productname", CategoryID = newCategory.CategoryID, SupplierID = 1 };
               var newProduct = _db.Products.Insert(product);

               var customer = new Customer { CompanyName = "Newcompanyname", ContactName = "ccc", Address = "asdcasdws" , ContactTitle="asdf", City="kuna", Country="china"
               , Fax="23", Phone="231", PostalCode="234", Region="asia"};
               //var newCustomer = _db.Customers.Insert(customer);

               //update
               //newCustomer.ContactName = "updated contact";
               //_db.Customers.Update(newCustomer);

               newCategory.CategoryName = "Updated";
               _db.Categories.Update(newCategory);

               newProduct.ProductName = "updated product";
               _db.Products.Update(newProduct);


               //delete
               _db.Products.DeleteByProductID(newProduct.ProductID); 
               _db.Categories.DeleteByCategoryID(newCategory.CategoryID);
              // _db.Customers.DeleteByCustomerID(newCustomer.CustomerID);
            
           }
       });
        }
    }
}
