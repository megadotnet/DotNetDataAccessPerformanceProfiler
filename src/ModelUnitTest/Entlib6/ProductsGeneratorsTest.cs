using System.Collections.Generic;
using DG.Common;
using DataGenerator;
using NUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;

namespace DataGeneratorTest1
{
    /// <summary>
    /// ProductsGeneratorsTest
    /// </summary>
    [TestFixture]
    public class ProductsGeneratorsTest
    {
        private ProductsRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            //http://codepattern.net/Blog/post/Database-provider-factory-not-set-for-the-static-DatabaseFactory
            //https://msdn.microsoft.com/en-us/library/dn440726(v=pandp.60).aspx
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());

            _productRepository = new ProductsRepository();
        }

        [Test]
        public void GetAllOperations()
        {
            var countries = _productRepository.GetAll();
            Assert.IsFalse(countries.Count == 0);
        }

        [Test]
        public void GetById()
        {
            var product = _productRepository.GetById(2);
            Assert.IsFalse(product.ProductID == 0);

        }
        [Test]
        public void Insert()
        {
            var product = new Products
            {
                ProductName = "ptest",
                QuantityPerUnit = "sadf",
                UnitPrice = 23,
                UnitsInStock = 1,
                UnitsOnOrder = 2
            };
            long insert = _productRepository.Insert(product);
            Assert.IsFalse(insert == 0);
        }

        //[Test]
        //public void Update()
        //{
        //    var country = new Country
        //                      {
        //        Id = 245,
        //        HasState = true,
        //        ISO = "CC",
        //        Name = "ABC",
        //        PrintableName = "ABC",
        //        ISO3 = "ABC"
        //    };
        //    _countryRepository.Update(country);
        //    Assert.IsFalse(false);
        //}

        [Test]
        public void AllbySort()
        {
            var shortItems = new List<SortItem> { new SortItem { ColumnName = "ProductName", SortOrder = SortOrder.DESC } };
            var sortDefinitions = new SortDefinitions();
            sortDefinitions.SoftItems.AddRange(shortItems);
            var allBySorting = _productRepository.GetAllBySorting(sortDefinitions);
            Assert.IsFalse(allBySorting.Count == 0);
        }
        //[Test]
        //public void SortWithPagination()
        //{
        //    var shortItems = new List<SortItem> { new SortItem { ColumnName = "ISO", SortOrder = SortOrder.DESC } };
        //    var sortDefinitions = new SortDefinitions();
        //    sortDefinitions.SoftItems.AddRange(shortItems);
        //    var allBySorting = _countryRepository.GetAllBySortingAndPaged(sortDefinitions,5,20);
        //    Assert.IsFalse(allBySorting.Count != 20);
        //}
    }
}
