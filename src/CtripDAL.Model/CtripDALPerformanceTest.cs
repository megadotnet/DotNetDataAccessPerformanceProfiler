// ***********************************************************************
// Assembly         : CtripDALPerformanceTest.Model
// Author           : PeterLiu
// Created          : 06-05-2017
//
// Last Modified By : PeterLiu
// Last Modified On : 06-05-2017
// ***********************************************************************
// <copyright file="CtripDALPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CtripDAL.Model
{
    using CtripDAL.Model.Entity.DataModel;
    using CtripDAL.Model.Interface.IDao;
    using DBPerformanceTest.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// CtripDALPerformanceTest
    /// </summary>
    public class CtripDALPerformanceTest : IPerformanceTest
    {
        private ICategoriesGenDao categoriesGenDao = DALFactory.CategoriesGenDao;
        private ICustomersGenDao customersGenDao = DALFactory.CustomersGenDao;
        private IProductsGenDao productsGenDao = DALFactory.ProductsGenDao;

        /// <summary>
        /// FetchAllTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchAllTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
       () =>
       {
           for (int i = 0; i < repeatTime; i++)
           {
               var categories = categoriesGenDao.GetAll();
               var customer = customersGenDao.GetAll();
               var product = productsGenDao.GetAll();
           }
       });
        }

        /// <summary>
        /// FetchSingleTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchSingleTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
() =>
{
    for (int i = 0; i < repeatTime; i++)
    {


        var categories = categoriesGenDao.FindByPk(10);
        var customer = customersGenDao.FindByPk("10");
        var product = productsGenDao.FindByPk(10);
    }
});
        }

        /// <summary>
        /// WriteTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long WriteTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
() =>
{
for (int i = 0; i < repeatTime; i++)
{
        var customer = new CustomersGen
        {
            CompanyName = "Newcvompanyname",
            ContactName = "ccc",
            Address = "asdcadsdws",
            ContactTitle = "adsdf",
            City = "ku2na",
            Country = "chi2na",
            Phone = "231",
            PostalCode = "234",
            Region = "ASIA",
            CustomerID = "9011"
        };

        int customerIdFromDb=customersGenDao.InsertCustomersGen(customer);

        var catagore = new CategoriesGen() { CategoryName = "xdf", Description = "asfb" };
        int categoryIDfromDb=categoriesGenDao.InsertCategoriesGen(
            catagore
            );

        var product = new ProductsGen
        {
            ProductName = "Blue Widget234",
            UnitPrice = 35.56M,
            CategoryID = categoryIDfromDb
        };

        //Insert
        product.ProductID=productsGenDao.InsertProductsGen(product
           );

        product.ProductName = "ProductNameChange";
        //Update
        productsGenDao.UpdateProductsGen(product);

        //Delete
        productsGenDao.DeleteProductsGen(product);
        customersGenDao.DeleteCustomersGen(customer);
        categoriesGenDao.DeleteCategoriesGen(catagore);


    }
});
        }
    }
}
