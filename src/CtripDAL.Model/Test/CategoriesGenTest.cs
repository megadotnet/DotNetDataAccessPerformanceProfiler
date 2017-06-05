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
    public class CategoriesGenTest
    {
        public static void Test()
        {
            //以下方法的主要目的是教会您如何使用DAL
            //在实际使用的时候，您需要根据不同的情形
            //反注释相应的代码，并传入合法的参数
            //-------其他可用的方法，VS的intellisense会告诉您的---------
            ICategoriesGenDao categoriesGenDao = DALFactory.CategoriesGenDao;


            //CategoriesGen orm = categoriesGenDao.OrmByHand("select * from table");

            //int insertResult = categoriesGenDao.InsertCategoriesGen(new CategoriesGen());

            //int updateResult = categoriesGenDao.UpdateCategoriesGen(new CategoriesGen());

            //int deleteResult = categoriesGenDao.DeleteCategoriesGen(new CategoriesGen());

            //int deleteByFieldResult = categoriesGenDao.DeleteCategoriesGen(0);


            //var resultsByPk = categoriesGenDao.FindByPk(0);
            //var entities = categoriesGenDao.GetAll();

            //long count = categoriesGenDao.Count();

            //var listByPage = categoriesGenDao.GetListByPage(null, 0, 0);

        }
    }
}
