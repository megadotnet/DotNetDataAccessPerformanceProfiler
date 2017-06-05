using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arch.Data;
using Arch.Data.DbEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CtripDAL.Model.Entity.DataModel;
using CtripDAL.Model.Interface.IDao;
using CtripDAL.Model.Dao;


namespace CtripDAL.Model.Test
{
	//在实际使用的时候，您需要根据不同的情形初始化参数值并反注释函数来运行test case
	[TestClass]
    public class ProductsGenUnitTest
    {

		IProductsGenDao productsGenDao = DALFactory.ProductsGenDao;

        [TestMethod]
        public void TestCount()
        {
            long ret = productsGenDao.Count();
        }
		
	    [TestMethod]
        public void TestDeleteProductsGen1()
        {
            //ProductsGen productsGen;
			//int ret = productsGenDao.DeleteProductsGen(productsGen);
        }
		
	    [TestMethod]
        public void TestFindByPk()
        {
            //int productID;
			//ProductsGen obj = productsGenDao.FindByPk(productID);
        }
		
	    [TestMethod]
        public void TestGetAll()
        {
            IList<ProductsGen> obj = productsGenDao.GetAll();
        }
		
        [TestMethod]
        public void TestGetListByPage()
        {
            //ProductsGen obj;
			//int pagesize;
			//int pageNo;
			//IList<ProductsGen> ret = productsGenDao.GetListByPage(obj, pagesize, pageNo);
        }
		
	    //sp insert
	    [TestMethod]
        public void TestInsertProductsGen()
        {
			//ProductsGen productsGen;
            //int ret = productsGenDao.InsertProductsGen(productsGen);
        }
		
        [TestMethod]
        public void TestUpdateProductsGen()
        {
			//ProductsGen productsGen;
            //int ret = productsGenDao.UpdateProductsGen(productsGen);
        }
		
    }
	
}
