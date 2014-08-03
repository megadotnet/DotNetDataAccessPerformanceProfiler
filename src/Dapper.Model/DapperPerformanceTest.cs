// ***********************************************************************
// Assembly         : Dapper.Model
// Author           : PeterLiu
// Created          : 08-03-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 08-03-2014
// ***********************************************************************
// <copyright file="DapperPerformanceTest.cs" company="Megadotnet">
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
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using DBPerformanceTest.Core.Model;

namespace Dapper.Model
{
    /// <summary>
    /// Class DapperPerformanceTest
    /// </summary>
    /// <seealso cref="http://stackoverflow.com/tags/dapper/info" />
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    /// <seealso cref="http://www.codeproject.com/Articles/212274/A-Look-at-Dapper-NET"/>
    public class DapperPerformanceTest : IPerformanceTest
    {
        /// <summary>
        /// My connection string
        /// </summary>
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;


        /// <summary>
        /// Usings the SQL connection.
        /// </summary>
        /// <typeparam name="TResult">The type of the T result.</typeparam>
        /// <param name="myFunc">My func.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        /// <example>
        /// <![CDATA[
        /// public MyEntity Read(int id)
        ///{
        ///return UsingSqlConnection((sqlConn) => MyDataLayer.Read(sqlConn, id));       
        ///}
        /// 
        /// ]]>
        /// </example>
        private TResult UsingSqlConnection<TResult>(Func<SqlConnection, TResult> myFunc)
        {
            using (SqlConnection sqlConn = new SqlConnection(myConnectionString))
            {
                sqlConn.Open();
                return myFunc(sqlConn);
            }
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
                    var products = sqlconn.Query<Product>("select * from Products");
                    var categoreis = sqlconn.Query<Category>("select * from Categories");
                    var customers = sqlconn.Query<Customer>("select * from Customers");
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
                  var products = sqlconn.Query<Product>("select * from Products where ProductID = 10");
                  var categoreis = sqlconn.Query<Category>("select * from Categories where CategoryID = 10");
                  var customers = sqlconn.Query<Customer>("select * from Customers where CustomerID = '10'");

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
                 CreateConnection(connection =>
                 {
                     CustmerCRUD(connection);

                     #region Category and product CRUD
                     var category = new Category { CategoryName = "Shipment2", Description = "for test2" };
                     //insert category
                     category.CategoryID = connection.Query<int>("insert into Categories (CategoryName, Description) values (@CategoryName, @Description);SELECT CAST(SCOPE_IDENTITY() as int)"
                         , new
                         {
                             category.CategoryName
                             ,
                             category.Description
                         }).Single();

                     //get it
                     var newcategory = connection.Query<Category>("select * from Categories where CategoryID = @CategoryID", new { category.CategoryID }).Single();

                     newcategory.CategoryName = "update2d3";

                     //update category
                     connection.Execute("update Categories set CategoryName =@CategoryName where CategoryID =@CategoryID"
                         , new
                         {
                             newcategory.CategoryName
                             ,
                             newcategory.CategoryID
                         });

                     //new product
                     var product = new Product { ProductName = "productname", CategoryID = category.CategoryID, SupplierID = 3, QuantityPerUnit = "test", UnitPrice = 10 };
                     product.ProductID= connection.Query<int>("insert into Products (ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice) values (@ProductName,@CategoryID ,@SupplierID, @QuantityPerUnit, @UnitPrice);SELECT CAST(SCOPE_IDENTITY() as int)"
                         , new { 
                          product.ProductName
                         ,product.CategoryID
                         ,product.SupplierID
                         ,product.QuantityPerUnit
                         ,product.UnitPrice
                         }).Single();

                     //update product
                     product.ProductName = "updateproducted";
                     connection.Execute("update Products set ProductName = @ProductName where ProductID =@ProductID "
                         , new { product.ProductName
                         , product.ProductID}); 

                     //delete product
                     connection.Execute("delete from Products where ProductID =@ProductID"
                         , new { product.ProductID});

                     //delete category
                     connection.Execute("delete from Categories where CategoryID =@CategoryID"
                         , new
                         {
                             category.CategoryID
                         }); 
                     #endregion

                 });

             });
        }

        /// <summary>
        /// Custmers the CRUD.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void CustmerCRUD(SqlConnection connection)
        {
            var customer = new Customer
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

            //insert
            int insertflag = connection.Execute("insert into Customers (CustomerID,CompanyName, ContactName, Address) values (@CustomerID,@CompanyName, @ContactName, @Address)",
                 new
                 {
                     customer.CustomerID
                     ,
                     customer.CompanyName
                     ,
                     customer.ContactName
                     ,
                     customer.Address
                 });

            //update 
            customer.CompanyName = "updatecust";
            connection.Execute("update Customers set CompanyName = @CompanyName where CustomerID = @CustomerID", new
            {
                customer.CustomerID
                ,
                customer.CompanyName
            });

            //delete
            connection.Execute("Delete from Customers where CustomerID=@CustomerID", new
            {
                customer.CustomerID
            });
        }
    }
}
