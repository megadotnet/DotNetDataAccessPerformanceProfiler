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
    ///CategoriesGenDao
    /// </summary>
    public partial class CategoriesGenDao : ICategoriesGenDao
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
        public CategoriesGen OrmByHand(string sql)
        {
            try
            {
                return baseDao.VisitDataReader<CategoriesGen>(sql, (reader) =>
                {
                    CategoriesGen entity = new CategoriesGen();
					if(reader.Read())
					{
                        entity.CategoryID = reader["CategoryID"];
                        entity.CategoryName = reader["CategoryName"];
                        entity.Description = reader["Description"];
                        entity.Picture = reader["Picture"];
                    }
                    return entity;
                });

                //CategoriesGen entity = new CategoriesGen();
                //using(var reader = baseDao.SelectDataReader(sql))
                //{
					//if(reader.Read())
					//{
                        //entity.CategoryID = reader["CategoryID"];
                        //entity.CategoryName = reader["CategoryName"];
                        //entity.Description = reader["Description"];
                        //entity.Picture = reader["Picture"];
	                //}
                //}
                //return entity;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGenDao时，访问OrmByHand时出错", ex);
            }
        }
        */
        /// <summary>
        /// 修改CategoriesGen
        /// </summary>
        /// <param name="categoriesGen">CategoriesGen实体对象</param>
        /// <returns>状态代码</returns>
        public int UpdateCategoriesGen(CategoriesGen categoriesGen)
        {
            try
            {
                Object result = baseDao.Update<CategoriesGen>(categoriesGen);
                int iReturn = Convert.ToInt32(result);

                return iReturn;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGen时，访问Update时出错", ex);
            }
        }
        /// <summary>
        /// 删除CategoriesGen
        /// </summary>
        /// <param name="categoriesGen">CategoriesGen实体对象</param>
        /// <returns>状态代码</returns>
        public int DeleteCategoriesGen(CategoriesGen categoriesGen)
        {
            try
            {
                Object result = baseDao.Delete<CategoriesGen>(categoriesGen);
                int iReturn = Convert.ToInt32(result);

                return iReturn;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGen时，访问Delete时出错", ex);
            }
        }
        /// <summary>
        /// 根据主键获取CategoriesGen信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns>CategoriesGen信息</returns>
        public CategoriesGen FindByPk(int categoryID )
        {
            try
            {
                return baseDao.GetByKey<CategoriesGen>(categoryID);
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGenDao时，访问FindByPk时出错", ex);
            }
        }
        /// <summary>
        /// 获取所有CategoriesGen信息
        /// </summary>
        /// <returns>CategoriesGen列表</returns>
        public IList<CategoriesGen> GetAll()
        {
            try
            {
                return baseDao.GetAll<CategoriesGen>();
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGenDao时，访问GetAll时出错", ex);
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
                String sql = "SELECT count(1) from Categories  with (nolock)  ";
                object obj = baseDao.ExecScalar(sql);
                long ret = Convert.ToInt64(obj);
                return ret;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGenDao时，访问Count时出错", ex);
            }
        }
        /// <summary>
        ///  检索CategoriesGen，带翻页
        /// </summary>
        /// <param name="obj">CategoriesGen实体对象检索条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageNo">页码</param>
        /// <returns>检索结果</returns>
        public IList<CategoriesGen> GetListByPage(CategoriesGen obj, int pagesize, int pageNo)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder(200);

                sbSql.Append(@"select CategoryID, CategoryName, Description, Picture from Categories (nolock) ");
                sbSql.Append(" order by CategoryID desc ");
                sbSql.Append(string.Format("OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", (pageNo - 1) * pagesize, pagesize));
                IList<CategoriesGen> list = baseDao.SelectList<CategoriesGen>(sbSql.ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGenDao时，访问GetListByPage时出错", ex);
            }
        }

       /// <summary>
       ///  批量插入CategoriesGen
       /// </summary>
       /// <param name="categoriesGen">CategoriesGen实体对象列表</param>
       /// <returns>状态代码</returns>
        public bool BulkInsertCategoriesGen(IList<CategoriesGen> categoriesGenList)
       	{
            try
            {
                return baseDao.BulkInsert<CategoriesGen>(categoriesGenList);
            }
            catch (Exception ex)
            {
                throw new DalException("调用CategoriesGenDao时，访问BulkInsert时出错", ex);
            }
        }

        public int InsertCategoriesGen(CategoriesGen categoriesGen)
        {
            throw new NotImplementedException();
        }
    }
}