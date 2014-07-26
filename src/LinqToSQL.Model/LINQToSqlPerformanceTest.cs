// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LINQToSqlPerformanceTest.cs" company="Megadotnet">
//   LINQToSqlPerformanceTest
// </copyright>
// <summary>
//   LINQToSqlPerformanceTest
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LinqToSQL.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using DBPerformanceTest.Core;

    /// <summary>
    /// LINQToSqlPerformanceTest
    /// </summary>
    public class LINQToSqlPerformanceTest : IPerformanceTest
    {
        #region Implemented Interfaces

        #region IPerformanceTest

        /// <summary>
        /// Fetches all test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The fetch all test.
        /// </returns>
        public long FetchAllTest(int repeatTime)
        {
            var sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            using (var db = new CategoryDataContext())
            {
                for (int i = 0; i < repeatTime; i++)
                {
                    List<Categories> cats = (from cat in db.Categories select cat).ToList();
                    List<Customers> cuses = (from cust in db.Customers select cust).ToList();
                    List<Products> products = (from p in db.Products select p).ToList();
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Fetches the single test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The fetch single test.
        /// </returns>
        public long FetchSingleTest(int repeatTime)
        {
            var sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            using (var db = new CategoryDataContext())
            {
                for (int i = 0; i < repeatTime; i++)
                {
                    List<Categories> cats = (from cat in db.Categories where cat.CategoryID == 10 select cat).ToList();
                    List<Customers> cuses =
                        (from cust in db.Customers where cust.CustomerID == "10" select cust).ToList();
                    List<Products> products = (from p in db.Products where p.ProductID == 10 select p).ToList();
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Writes the test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The write test.
        /// </returns>
        public long WriteTest(int repeatTime)
        {
            var sw = new Stopwatch();
            sw.Reset();
            sw.Start();

            var db = new CategoryDataContext();
            var db3 = new CategoryDataContext();
            var db2 = new CategoryDataContext();
            for (int i = 0; i < repeatTime; i++)
            {
                var cus = new Customers
                    {
                        CustomerID = "test", 
                        CompanyName = "company name", 
                        ContactName = "contact name", 
                        Address = "address"
                    };
                db.Customers.InsertOnSubmit(cus);
                db.SubmitChanges();

                cus.CompanyName = "update name";
                db.SubmitChanges();

                var cat = new Categories { CategoryName = "Widgets", Description = "Widgets are the ……" };
                var newProduct = new Products { ProductName = "Blue Widget", UnitPrice = 34.56M, Categories = cat };

                db.Categories.InsertOnSubmit(cat);
                db.SubmitChanges();

                cat.CategoryName = "testupdated";
                db.SubmitChanges();

                

                Products p3 = db3.Products.First(c => c.ProductName == "Blue Widget");
                p3.UnitPrice = 15.8M;
                db3.SubmitChanges();

                

                #region New a datacontent for delete Products

                Products p2 = db2.Products.First(c => c.ProductName == "Blue Widget");
                db2.Products.DeleteOnSubmit(p2);
                db2.SubmitChanges();

                #endregion

                Categories cat2 = db.Categories.First(c => c.CategoryName == "testupdated");

                db.Categories.DeleteOnSubmit(cat2);
                db.SubmitChanges();

                db.Customers.DeleteOnSubmit(cus);
                db.SubmitChanges();
            }

            db.Dispose();
            db2.Dispose();
            db3.Dispose();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        #endregion

        #endregion
    }
}