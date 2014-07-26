// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LINQToEntityPerformanceTest.cs" company="Megadotnet">
//   LINQToEntityPerformanceTest
// </copyright>
// <summary>
//   LINQToEntityPerformanceTest
//   http://thedatafarm.com/blog/data-access/looking-at-ef-performance-some-surprises
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EntityFrameworkTest
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using DBPerformanceTest.Core;

    /// <summary>
    /// LINQToEntityPerformanceTest
    /// http://thedatafarm.com/blog/data-access/looking-at-ef-performance-some-surprises/
    /// </summary>
    public class LINQToEntityPerformanceTest : IPerformanceTest
    {
        #region Public Methods

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The to string.
        /// </returns>
        public override string ToString()
        {
            return "EntityFamework4.0";
        }

        #endregion

        #region Implemented Interfaces

        #region IPerformanceTest

        /// <summary>
        /// The fetch all test.
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

            using (var db = new TestPerformaceDBEntities())
            {
                for (int i = 0; i < repeatTime; i++)
                {
                    List<Categories> cats = db.Categories.ToList();
                    List<Customers> cuses = db.Customers.ToList();
                    List<Products> products = db.Products.ToList();
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// The fetch single test.
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

            using (var db = new TestPerformaceDBEntities())
            {
                for (int i = 0; i < repeatTime; i++)
                {
                    // use entity sql is more faster
                    List<Categories> cats = db.Categories.Where("it.CategoryID=10").ToList();
                    List<Customers> cuses = db.Customers.Where("it.CustomerID='10'").ToList();
                    List<Products> products = db.Products.Where("it.ProductID=10").ToList();

                    // use linq to entities

                    // var cats = db.Categories.Where(cat => cat.CategoryID == 10).ToList();
                    // var cuses = db.Customers.Where(cut => cut.CustomerID == "10").ToList();
                    // var products = db.Products.Where(p => p.ProductID == 10).ToList();
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

            using (var db = new TestPerformaceDBEntities())
            {
                for (int i = 0; i < repeatTime; i++)
                {
                    var cus = new Customers
                        {
                            CustomerID = "test", 
                            CompanyName = "company name", 
                            ContactName = "contact name", 
                            Address = "address"
                        };

                    db.AddObject("Customers", cus);
                    db.SaveChanges();

                    cus.CompanyName = "update name";
                    db.SaveChanges();

                    var cat = new Categories { CategoryName = "Widgets", Description = "Widgets are the ……" };

                    // if we have fk
                    // db.AddToCategories(cat);
                    // db.SaveChanges();
                    var newProduct = new Products { ProductName = "Blue Widget", UnitPrice = 34.56M, Categories = cat };

                    db.AddObject("Products", newProduct);
                    db.SaveChanges();

                    // Update
                    cat.CategoryName = "testupdated";
                    db.SaveChanges();

                    newProduct.UnitPrice = 15.8M;
                    db.SaveChanges();

                    // Delete
                    db.DeleteObject(newProduct);
                    db.SaveChanges();

                    db.DeleteObject(cus);
                    db.SaveChanges();

                    db.DeleteObject(cat);
                    db.SaveChanges();
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        #endregion

        #endregion
    }
}