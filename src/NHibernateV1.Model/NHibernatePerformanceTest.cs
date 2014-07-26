// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NHibernatePerformanceTest.cs" company="Megadotnet">
//   NHibernatePerformanceTest
// </copyright>
// <summary>
//   The n hibernate performance test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernateV1.Model
{
    using System.Collections;
    using System.Diagnostics;

    using DBPerformanceTest.Core;

    using NH;

    /// <summary>
    /// The nhibernate performance testing class
    /// </summary>
    /// <remarks>Here is only work with NHibernate verion 1.02 </remarks>
    /// <seealso cref="http://olex.openlogic.com/packages/nhibernate/1.0.2"/>
    public class NHibernatePerformanceTest : IPerformanceTest
    {
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
            var session = Sessions.GetSession();
            for (int i = 0; i < repeatTime; i++)
            {
                IList cats = session.Find("from NH.Category");
                IList cuses = session.Find("from NH.Customer");
                IList products = session.Find("from NH.Product");
            }

            session.Close();
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
            var session = Sessions.GetSession();
            for (int i = 0; i < repeatTime; i++)
            {
                IList cats = session.Find("from NH.Category where CategoryID = 10");
                IList cuses = session.Find("from NH.Customer where CustomerID = '10'");
                IList products = session.Find("from NH.Product where ProductID = 10");
            }

            session.Close();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// The write test.
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
            for (int i = 0; i < repeatTime; i++)
            {
                var cat = new Category { CategoryName = "category1", Description = "category1" };
                cat.Create();

                cat.CategoryName = "testupdated";
                cat.Update();

                var p = new Product
                    {
                        ProductName = "test", 
                        CategoryID = cat.CategoryID, 
                        SupplierID = 3, 
                        QuantityPerUnit = "test", 
                        UnitPrice = 10.5M
                    };
                p.Create();

                p.UnitPrice = 15.8M;
                p.Update();

                p.Delete();
                cat.Delete();

                // ---
                var cus = new Customer
                    {
                        CustomerID = "test", 
                        CompanyName = "company name", 
                        ContactName = "contact name", 
                        Address = "address"
                    };
                cus.Create();

                cus.CompanyName = "update name";
                cus.Update();

                // ---
                cus.Delete();
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        #endregion

        #endregion
    }
}