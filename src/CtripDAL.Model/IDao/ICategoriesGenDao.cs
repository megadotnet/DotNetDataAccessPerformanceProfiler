using System;
using System.Collections.Generic;
using CtripDAL.Model.Entity.DataModel;

namespace CtripDAL.Model.Interface.IDao
{
        public partial interface ICategoriesGenDao
        {

        /// <summary>
        ///  插入CategoriesGen
        /// </summary>
        /// <param name="categoriesGen">CategoriesGen实体对象</param>
        /// <returns>状态代码</returns>
		int InsertCategoriesGen(CategoriesGen categoriesGen);
        /// <summary>
        /// 修改CategoriesGen
        /// </summary>
        /// <param name="categoriesGen">CategoriesGen实体对象</param>
        /// <returns>状态代码</returns>
        int UpdateCategoriesGen(CategoriesGen categoriesGen);
        /// <summary>
        /// 删除CategoriesGen
        /// </summary>
        /// <param name="categoriesGen">CategoriesGen实体对象</param>
        /// <returns>状态代码</returns>
        int DeleteCategoriesGen(CategoriesGen categoriesGen);
        /// <summary>
        /// 根据主键获取CategoriesGen信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns>CategoriesGen信息</returns>
        CategoriesGen FindByPk(int categoryID);
        /// <summary>
        /// 获取所有CategoriesGen信息
        /// </summary>
        /// <returns>CategoriesGen列表</returns>
        IList<CategoriesGen> GetAll();
        /// <summary>
        /// 取得总记录数
        /// </summary>
        /// <returns>记录数</returns>
        long Count();
        /// <summary>
        ///  批量插入CategoriesGen
        /// </summary>
        /// <param name="categoriesGen">CategoriesGen实体对象列表</param>
        /// <returns>状态代码</returns>
        bool BulkInsertCategoriesGen(IList<CategoriesGen> categoriesGenList);
        /// <summary>
        ///  检索CategoriesGen，带翻页
        /// </summary>
        /// <param name="obj">CategoriesGen实体对象检索条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageNo">页码</param>
        /// <returns>检索结果</returns>
        IList<CategoriesGen> GetListByPage(CategoriesGen obj, int pagesize, int pageNo);


        }
}