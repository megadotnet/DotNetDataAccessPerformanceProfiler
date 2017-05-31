// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntLibDAABPerformanceTest.cs" company="Megadotnet">
//   EntLibDAABPerformanceTest
// </copyright>
// <summary>
//   EntLibDAABPerformanceTest
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EntDAAB.Model
{
    using System;
    using System.Data;

    using DBPerformanceTest.Core;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// EntLibDAABPerformanceTest
    /// </summary>
    public class EntLibDAABPerformanceTest : IPerformanceTest
    {
        #region Constants and Fields

        /// <summary>
        /// Databases
        /// </summary>
        private static Database _db;

        #endregion

        /// <summary>
        /// EntLibDAABPerformanceTest
        /// </summary>
        static EntLibDAABPerformanceTest()
        {
            //http://codepattern.net/Blog/post/Database-provider-factory-not-set-for-the-static-DatabaseFactory
            //https://msdn.microsoft.com/en-us/library/dn440726(v=pandp.60).aspx
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
        }

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntLibDAABPerformanceTest"/> class.
        /// </summary>
        public EntLibDAABPerformanceTest()
        {
            _db = DatabaseFactory.CreateDatabase("TestDB");
        }

        #endregion

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
            return Utility.PerformanceWatch(
                () =>
                    {
                        for (int i = 0; i < repeatTime; i++)
                        {
                            DataSet cats = _db.ExecuteDataSet(CommandType.Text, "select * from Categories");
                            DataSet cuses = _db.ExecuteDataSet(CommandType.Text, "select * from Customers");
                            DataSet products = _db.ExecuteDataSet(CommandType.Text, "select * from Products");
                        }
                    });
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
            return Utility.PerformanceWatch(
                () =>
                    {
                        for (int i = 0; i < repeatTime; i++)
                        {
                            DataSet cats = _db.ExecuteDataSet(
                                CommandType.Text, "select * from Categories where CategoryID = 10");
                            DataSet cuses = _db.ExecuteDataSet(
                                CommandType.Text, "select * from Customers where CustomerID = '10'");
                            DataSet products = _db.ExecuteDataSet(
                                CommandType.Text, "select * from Products where ProductID = 10");
                        }
                    });
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
            return Utility.PerformanceWatch(
                () =>
                    {
                        for (int i = 0; i < repeatTime; i++)
                        {
                            string sql =
                                "insert into Categories (CategoryName, Description) values ('category1', 'category1');select SCOPE_IDENTITY()";
                            int catID = Convert.ToInt32(_db.ExecuteScalar(CommandType.Text, sql));
                            _db.ExecuteNonQuery(
                                CommandType.Text, 
                                "update Categories set CategoryName = 'testupdate' where CategoryID =" + catID);

                            _db.ExecuteNonQuery(
                                CommandType.Text, 
                                "insert into Customers (CustomerID, CompanyName, ContactName, Address) values ('test', 'company name', 'contact name', 'address')");
                            _db.ExecuteNonQuery(
                                CommandType.Text, 
                                "update Customers set CompanyName = 'testupdate' where CustomerID = 'test'");

                            int productID =
                                Convert.ToInt32(
                                    _db.ExecuteScalar(
                                        CommandType.Text, 
                                        string.Format(
                                            "insert into Products (ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice) values ('test',{0} ,3, 'test', 10.5);select SCOPE_IDENTITY()", 
                                            catID)));
                            _db.ExecuteNonQuery(
                                CommandType.Text, "update Products set UnitPrice = 16.8 where ProductID = " + productID);

                            _db.ExecuteNonQuery(CommandType.Text, "delete from Products where ProductID = " + productID);
                            _db.ExecuteNonQuery(CommandType.Text, "delete from Customers where CustomerID = 'test'");
                            _db.ExecuteNonQuery(CommandType.Text, "delete from Categories where CategoryID = " + catID);
                        }
                    });
        }

        #endregion

        #endregion
    }
}