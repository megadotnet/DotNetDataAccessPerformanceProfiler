using System;
using System.Collections.Generic;
using CtripDAL.Model.Entity.DataModel;

namespace CtripDAL.Model.Interface.IDao
{
        public partial interface ICustomersGenDao
        {

        /// <summary>
        ///  插入CustomersGen
        /// </summary>
        /// <param name="customersGen">CustomersGen实体对象</param>
        /// <returns>状态代码</returns>
		int InsertCustomersGen(CustomersGen customersGen);
        /// <summary>
        /// 修改CustomersGen
        /// </summary>
        /// <param name="customersGen">CustomersGen实体对象</param>
        /// <returns>状态代码</returns>
        int UpdateCustomersGen(CustomersGen customersGen);
        /// <summary>
        /// 删除CustomersGen
        /// </summary>
        /// <param name="customersGen">CustomersGen实体对象</param>
        /// <returns>状态代码</returns>
        int DeleteCustomersGen(CustomersGen customersGen);
        /// <summary>
        /// 根据主键获取CustomersGen信息
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>CustomersGen信息</returns>
        CustomersGen FindByPk(string customerID);
        /// <summary>
        /// 获取所有CustomersGen信息
        /// </summary>
        /// <returns>CustomersGen列表</returns>
        IList<CustomersGen> GetAll();
        /// <summary>
        /// 取得总记录数
        /// </summary>
        /// <returns>记录数</returns>
        long Count();
        /// <summary>
        ///  批量插入CustomersGen
        /// </summary>
        /// <param name="customersGen">CustomersGen实体对象列表</param>
        /// <returns>状态代码</returns>
        bool BulkInsertCustomersGen(IList<CustomersGen> customersGenList);
        /// <summary>
        ///  检索CustomersGen，带翻页
        /// </summary>
        /// <param name="obj">CustomersGen实体对象检索条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageNo">页码</param>
        /// <returns>检索结果</returns>
        IList<CustomersGen> GetListByPage(CustomersGen obj, int pagesize, int pageNo);


        }
}