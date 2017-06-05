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
    public class CustomersGenUnitTest
    {

		ICustomersGenDao customersGenDao = DALFactory.CustomersGenDao;

        [TestMethod]
        public void TestCount()
        {
            long ret = customersGenDao.Count();
        }
		
	    [TestMethod]
        public void TestDeleteCustomersGen1()
        {
            //CustomersGen customersGen;
			//int ret = customersGenDao.DeleteCustomersGen(customersGen);
        }
		
	    [TestMethod]
        public void TestFindByPk()
        {
            //string customerID;
			//CustomersGen obj = customersGenDao.FindByPk(customerID);
        }
		
	    [TestMethod]
        public void TestGetAll()
        {
            IList<CustomersGen> obj = customersGenDao.GetAll();
        }
		
        [TestMethod]
        public void TestGetListByPage()
        {
            //CustomersGen obj;
			//int pagesize;
			//int pageNo;
			//IList<CustomersGen> ret = customersGenDao.GetListByPage(obj, pagesize, pageNo);
        }
		
	    //sp insert
	    [TestMethod]
        public void TestInsertCustomersGen()
        {
			//CustomersGen customersGen;
            //int ret = customersGenDao.InsertCustomersGen(customersGen);
        }
		
        [TestMethod]
        public void TestUpdateCustomersGen()
        {
			//CustomersGen customersGen;
            //int ret = customersGenDao.UpdateCustomersGen(customersGen);
        }
		
    }
	
}
