using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arch.Data;
using Arch.Data.DbEngine;
using CtripDAL.Model.Entity.DataModel;
using CtripDAL.Model.Interface.IDao;
using CtripDAL.Model.Dao;

namespace CtripDAL.Model.Test
{
    public class CustomersGenTest
    {
        public static void Test()
        {
            //以下方法的主要目的是教会您如何使用DAL
            //在实际使用的时候，您需要根据不同的情形
            //反注释相应的代码，并传入合法的参数
            //-------其他可用的方法，VS的intellisense会告诉您的---------
            ICustomersGenDao customersGenDao = DALFactory.CustomersGenDao;


            //CustomersGen orm = customersGenDao.OrmByHand("select * from table");

            //int insertResult = customersGenDao.InsertCustomersGen(new CustomersGen());

            //int updateResult = customersGenDao.UpdateCustomersGen(new CustomersGen());

            //int deleteResult = customersGenDao.DeleteCustomersGen(new CustomersGen());

            //int deleteByFieldResult = customersGenDao.DeleteCustomersGen(null);


            //var resultsByPk = customersGenDao.FindByPk(null);
            //var entities = customersGenDao.GetAll();

            //long count = customersGenDao.Count();

            //var listByPage = customersGenDao.GetListByPage(null, 0, 0);

        }
    }
}
