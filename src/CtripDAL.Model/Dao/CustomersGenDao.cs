using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Arch.Data;
using Arch.Data.DbEngine;
using CtripDAL.Model.Entity.DataModel;
using CtripDAL.Model.Interface.IDao;

namespace CtripDAL.Model.Dao
{
    /// <summary>
    ///
    /// </summary>
    public partial class CustomersGenDao : ICustomersGenDao
    {
        readonly BaseDao baseDao = BaseDaoFactory.CreateBaseDao("TestPrerdb");
        
        //特别注意，如果是可空类型，建议以如下方式使用：
        // var data = reader["field"];
        // entity.stringData = data == null ? data : data.ToString();
        //如需要手工映射，请反注释如下代码，并注意转换类型
        /*
        /// <summary>
        /// 手工映射，建议使用1.2.0.5版本以上的VisitDataReader
        /// </summary>
        /// <returns>结果</returns>
        public CustomersGen OrmByHand(string sql)
        {
            try
            {
                return baseDao.VisitDataReader<CustomersGen>(sql, (reader) =>
                {
                    CustomersGen entity = new CustomersGen();
					if(reader.Read())
					{
                        entity.Address = reader["Address"];
                        entity.City = reader["City"];
                        entity.CompanyName = reader["CompanyName"];
                        entity.ContactName = reader["ContactName"];
                        entity.ContactTitle = reader["ContactTitle"];
                        entity.Country = reader["Country"];
                        entity.CustomerID = reader["CustomerID"];
                        entity.Fax = reader["Fax"];
                        entity.Phone = reader["Phone"];
                        entity.PostalCode = reader["PostalCode"];
                        entity.Region = reader["Region"];
                    }
                    return entity;
                });

                //CustomersGen entity = new CustomersGen();
                //using(var reader = baseDao.SelectDataReader(sql))
                //{
					//if(reader.Read())
					//{
                        //entity.Address = reader["Address"];
                        //entity.City = reader["City"];
                        //entity.CompanyName = reader["CompanyName"];
                        //entity.ContactName = reader["ContactName"];
                        //entity.ContactTitle = reader["ContactTitle"];
                        //entity.Country = reader["Country"];
                        //entity.CustomerID = reader["CustomerID"];
                        //entity.Fax = reader["Fax"];
                        //entity.Phone = reader["Phone"];
                        //entity.PostalCode = reader["PostalCode"];
                        //entity.Region = reader["Region"];
	                //}
                //}
                //return entity;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGenDao时，访问OrmByHand时出错", ex);
            }
        }
        */
        /// <summary>
        /// 修改CustomersGen
        /// </summary>
        /// <param name="customersGen">CustomersGen实体对象</param>
        /// <returns>状态代码</returns>
        public int UpdateCustomersGen(CustomersGen customersGen)
        {
            try
            {
                Object result = baseDao.Update<CustomersGen>(customersGen);
                int iReturn = Convert.ToInt32(result);

                return iReturn;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGen时，访问Update时出错", ex);
            }
        }
        /// <summary>
        /// 删除CustomersGen
        /// </summary>
        /// <param name="customersGen">CustomersGen实体对象</param>
        /// <returns>状态代码</returns>
        public int DeleteCustomersGen(CustomersGen customersGen)
        {
            try
            {
                Object result = baseDao.Delete<CustomersGen>(customersGen);
                int iReturn = Convert.ToInt32(result);

                return iReturn;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGen时，访问Delete时出错", ex);
            }
        }
        /// <summary>
        /// 根据主键获取CustomersGen信息
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>CustomersGen信息</returns>
        public CustomersGen FindByPk(string customerID )
        {
            try
            {
                return baseDao.GetByKey<CustomersGen>(customerID);
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGenDao时，访问FindByPk时出错", ex);
            }
        }
        /// <summary>
        /// 获取所有CustomersGen信息
        /// </summary>
        /// <returns>CustomersGen列表</returns>
        public IList<CustomersGen> GetAll()
        {
            try
            {
                return baseDao.GetAll<CustomersGen>();
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGenDao时，访问GetAll时出错", ex);
            }
        }
        /// <summary>
        /// 取得总记录数
        /// </summary>
        /// <returns>记录数</returns>
        public long Count()
        {
            try
            {
                String sql = "SELECT count(1) from Customers  with (nolock)  ";
                object obj = baseDao.ExecScalar(sql);
                long ret = Convert.ToInt64(obj);
                return ret;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGenDao时，访问Count时出错", ex);
            }
        }
        /// <summary>
        ///  检索CustomersGen，带翻页
        /// </summary>
        /// <param name="obj">CustomersGen实体对象检索条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageNo">页码</param>
        /// <returns>检索结果</returns>
        public IList<CustomersGen> GetListByPage(CustomersGen obj, int pagesize, int pageNo)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder(200);

                sbSql.Append(@"select Address, City, CompanyName, ContactName, ContactTitle, Country, CustomerID, Fax, Phone, PostalCode, Region from Customers (nolock) ");
                sbSql.Append(" order by CustomerID desc ");
                sbSql.Append(string.Format("OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", (pageNo - 1) * pagesize, pagesize));
                IList<CustomersGen> list = baseDao.SelectList<CustomersGen>(sbSql.ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGenDao时，访问GetListByPage时出错", ex);
            }
        }

       /// <summary>
       ///  批量插入CustomersGen
       /// </summary>
       /// <param name="customersGen">CustomersGen实体对象列表</param>
       /// <returns>状态代码</returns>
        public bool BulkInsertCustomersGen(IList<CustomersGen> customersGenList)
       	{
            try
            {
                return baseDao.BulkInsert<CustomersGen>(customersGenList);
            }
            catch (Exception ex)
            {
                throw new DalException("调用CustomersGenDao时，访问BulkInsert时出错", ex);
            }
        }

        public int InsertCustomersGen(CustomersGen customersGen)
        {
            throw new NotImplementedException();
        }
    }
}