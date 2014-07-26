// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntDAABModelTest.cs" company="Megadotnet">
//   EntDAABModelTest
// </copyright>
// <summary>
//   The ent daab model test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ModelUnitTest
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    using DBPerformanceTest.Core.Model;

    using Microsoft.Practices.EnterpriseLibrary.Data;
    using NUnit.Framework;

    /// <summary>
    /// The ent daab model test.
    /// </summary>
    [TestFixture]
    public class EntDAABModelTest
    {
        #region Public Methods

        /// <summary>
        /// The test get data.
        /// </summary>
        [Test]
        public void TestGetData()
        {
            string cxx = "SELECT * FROM [Products] where ProductID=@ProductID";
            var paras = new SqlParameter
                {
                    DbType = DbType.Int32, 
                    Direction = ParameterDirection.Input, 
                    Value = 1, 
                    Size = 4, 
                    ParameterName = "ProductID"
                };
            int flag = DataAccessorFactory.Create("TestDB").ExecuteNonQuery(cxx, new DbParameter[] { paras });
        }

        /// <summary>
        /// The test native ent lib execute scalar single value.
        /// </summary>
        [Test]
        public void TestNativeEntLibExecuteScalarSingleValue()
        {
            string cxx = "SELECT ProductName FROM [Products] where ProductID=@ProductID";
            Database db = DatabaseFactory.CreateDatabase("TestDB");
            DbCommand cmd = db.GetSqlStringCommand(cxx);
            db.AddInParameter(cmd, "ProductID", DbType.Int32, 1);

            var flag = (string)db.ExecuteScalar(cmd);

            Assert.IsNotNull(flag);
            Assert.AreEqual("testpro0", flag);
        }

        /// <summary>
        /// Tests the use AutoMapper library map the entity.
        /// </summary>
        [Test]
        public void TestUseAutoMapperEntity()
        {
            string tsqlstr = "SELECT Top 1 * FROM [Products] ";
            Database db = DatabaseFactory.CreateDatabase("TestDB");
            var cmd = db.GetSqlStringCommand(tsqlstr);

            var product = new Product();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    //auto map
                    product = AutoMapper.Mapper.DynamicMap<Product>(reader);
                }
            }

            Assert.IsNotNull(product);
            Console.WriteLine(product.ProductName);
        }
        #endregion
    }
}