// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestIUnitOfWork.cs" company="">
//   ModelUnitTest
// </copyright>
// <summary>
//   The test i unit of work.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ModelUnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EntityFrameworkTest;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// The test i unit of work.
    /// </summary>
    [TestFixture]
    public class TestIUnitOfWork
    {
        #region Public Methods

        /// <summary>
        /// The test db use same unitofwork.
        /// </summary>
        [Test]
        public void TestDbUseSameUnitofwork()
        {
            using (var contextAdapter = ObjectFactory.GetInstance<IObjectContext>())
            {
                using (var unitOfWork = new EFUnitOfWork(contextAdapter))
                {
                    var onerp = new ProductsRepository(new EFRepository<Products>(contextAdapter), unitOfWork);
                    var tworp = new CategoriesRepository(new EFRepository<Categories>(contextAdapter), unitOfWork);

                    Assert.AreSame(onerp.Repository.UnitOfWork, tworp.Repository.UnitOfWork);
                }
            }
        }

        /// <summary>
        /// The test db use same unitofwork 2.
        /// </summary>
        [Test]
        // [Ignore]
        public void TestDbUseSameUnitofwork2()
        {
            using (var contextAdapter = ObjectFactory.GetInstance<IObjectContext>())
            {
                var unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();

                ProductsRepository onerp = RepositoryHelper.GetProductsRepository(unitOfWork);
                ProductsRepository tworp = RepositoryHelper.GetProductsRepository(unitOfWork);
                Assert.AreSame(onerp.Repository.UnitOfWork, tworp.Repository.UnitOfWork);
            }
        }

        /// <summary>
        /// The test db use same unitofwork 4.
        /// </summary>
        [Test]
        public void TestDbUseSameUnitofwork4()
        {
            var unit = ObjectFactory.GetInstance<IUnitOfWork>();
            ProductsRepository onerp = RepositoryHelper.GetProductsRepository(unit);
            CategoriesRepository tworp = RepositoryHelper.GetCategoriesRepository(unit);

            Assert.AreEqual(onerp.Repository.UnitOfWork.GetHashCode(), tworp.Repository.UnitOfWork.GetHashCode());
        }

        /// <summary>
        /// The test db use same unitofwork and context adapter.
        /// </summary>
        [Test]
        public void TestDbUseSameUnitofworkAndContextAdapter()
        {
            using (var contextAdapter = ObjectFactory.GetInstance<IObjectContext>())
            {
                var unit = ObjectFactory.GetInstance<IUnitOfWork>();
                ProductsRepository onerp = RepositoryHelper.GetProductsRepository(unit, contextAdapter);
                CategoriesRepository tworp = RepositoryHelper.GetCategoriesRepository(unit, contextAdapter);

                Assert.AreSame(onerp.Repository.UnitOfWork, tworp.Repository.UnitOfWork);
            }
        }

        /// <summary>
        /// The test get db data use di.
        /// </summary>
        [Test]
        public void TestGetDBDataUseDI()
        {
            IRepository<Products> productRepository = RepositoryHelper.GetRepository<Products>();
            IEnumerable<Products> resultset = productRepository.Find(p => p.ProductID == 1);

            Assert.IsNotNull(resultset);
            Assert.IsNotNull(resultset.FirstOrDefault().ProductName);
        }

        /// <summary>
        /// The test get db data with out di.
        /// </summary>
        [Test]
        public void TestGetDBDataWithOutDI()
        {
            var dbcontext = new TestPerformaceDBEntities();
            var contextAdapter = new ObjectContextAdapter(dbcontext);
            var productRepository = new ProductsRepository(
                new EFRepository<Products>(contextAdapter), new EFUnitOfWork(contextAdapter));

            IEnumerable<Products> resultset = productRepository.Repository.Find(p => p.ProductID == 1);

            Assert.IsNotNull(resultset);
            Assert.IsNotNull(resultset.FirstOrDefault().ProductName);
        }

        /// <summary>
        /// IEFs the unit of work test.
        /// </summary>
        [Test]
        public void TestIUnitOfWorkInterface()
        {
            Assert.Throws<NotImplementedException>(() => {
                // arrange
                // mock
                var mockunit = new Mock<IUnitOfWork>();

            mockunit.Setup(u => u.Save()).Throws(new NotImplementedException());

            // assert
            mockunit.Object.Save();
            });

        }

        #endregion
    }
}