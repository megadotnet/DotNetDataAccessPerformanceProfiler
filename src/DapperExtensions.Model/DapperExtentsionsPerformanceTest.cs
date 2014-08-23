// ***********************************************************************
// Assembly         : DapperExtensions.Model
// Author           : PeterLiu
// Created          : 08-22-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 08-22-2014
// ***********************************************************************
// <copyright file="DapperExtentsionsPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DBPerformanceTest.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DapperExtensions.Model
{
    /// <summary>
    /// asdf
    /// </summary>
    /// <seealso cref="https://github.com/tmsmith/Dapper-Extensions" />
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class DapperExtentsionsPerformanceTest : IPerformanceTest
    {
        /// <summary>
        /// My connection string
        /// </summary>
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;


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
                          CreateConnection(sqlconn =>
                          {
                             var productlist = sqlconn.GetList<Products>();
                             var customerList = sqlconn.GetList<Customers>();
                             var categoryList = sqlconn.GetList<Categories>();

                          });
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
               CreateConnection(sqlconn =>
               {
                   var predicate = Predicates.Field<Products>(f => f.ProductID, Operator.Eq, 10);
                   IEnumerable<Products> productlist = sqlconn.GetList<Products>(predicate);

                   var customerPredicate = Predicates.Field<Customers>(f => f.CustomerID, Operator.Eq, "10");
                   IEnumerable<Customers> customerList = sqlconn.GetList<Customers>(customerPredicate);

                   var categoryPredicate = Predicates.Field<Categories>(f => f.CategoryID, Operator.Eq, 10);
                   IEnumerable<Categories> categoryList = sqlconn.GetList<Categories>(categoryPredicate);

               });
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
                          CreateConnection(sqlconn =>
                          {
                              CustomerCRUD(sqlconn);

                              var category = new Categories { CategoryName = "Shipment2", Description = "for test2" };

                              //insert
                              int insertflag = sqlconn.Insert<Categories>(category);

                              //update
                              var myCategory = sqlconn.Get<Categories>(insertflag);
                              myCategory.CategoryName = "updated name";


                              //product 
                              var product = new Products { ProductName = "productname"
                                  , CategoryID = category.CategoryID
                                  , SupplierID = 3, QuantityPerUnit = "test"
                                  , UnitPrice = 10 
                                };

                              //TODO: debug with source code
                              //Cannot insert explicit value for identity column in table 'Products' when IDENTITY_INSERT is set to OFF.
                              //int newProductId = sqlconn.Insert<Products>(product);

                              //update
                              //var myProduct = sqlconn.Get<Products>(newProductId);
                             // myProduct.ProductName = "update product name";

                              //sqlconn.Update<Products>(myProduct);

                              //delete
                              //sqlconn.Delete<Products>(myProduct);


                              //Exception: Operand type clash: nvarchar is incompatible with image
                              // sqlconn.Update<Categories>(myCategory);

                              //delete
                              sqlconn.Delete<Categories>(myCategory);
                          });
                      });

        }

        /// <summary>
        /// Customers the CRUD.
        /// </summary>
        /// <param name="sqlconn">The sqlconn.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void CustomerCRUD(SqlConnection sqlconn)
        {
            var customer = new Customers
            {
                CustomerID = "8273",
                CompanyName = "Newcompanyname",
                ContactName = "ccc",
                Address = "asdcasdws",
                ContactTitle = "asdf",
                City = "kuna",
                Country = "china",
                Fax = "23",
                Phone = "231",
                PostalCode = "234",
                Region = "asia"
            };

            string insertflag = sqlconn.Insert<Customers>(customer);

            //update it
            var myCustomer = sqlconn.Get<Customers>(customer.CustomerID);
            myCustomer.ContactName = "updated name";

            sqlconn.Update<Customers>(myCustomer);

            //delete
            sqlconn.Delete<Customers>(customer);
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void CreateConnection(Action<SqlConnection> action)
        {
            using (SqlConnection sqlConn = new SqlConnection(myConnectionString))
            {
                sqlConn.Open();
                action(sqlConn);
                sqlConn.Close();
            }
        }
    }
}
