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
    public partial class ProductsGenDao : IProductsGenDao
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
        public ProductsGen OrmByHand(string sql)
        {
            try
            {
                return baseDao.VisitDataReader<ProductsGen>(sql, (reader) =>
                {
                    ProductsGen entity = new ProductsGen();
					if(reader.Read())
					{
                        entity.CategoryID = reader["CategoryID"];
                        entity.Discontinued = reader["Discontinued"];
                        entity.ProductID = reader["ProductID"];
                        entity.ProductName = reader["ProductName"];
                        entity.QuantityPerUnit = reader["QuantityPerUnit"];
                        entity.ReorderLevel = reader["ReorderLevel"];
                        entity.SupplierID = reader["SupplierID"];
                        entity.UnitPrice = reader["UnitPrice"];
                        entity.UnitsInStock = reader["UnitsInStock"];
                        entity.UnitsOnOrder = reader["UnitsOnOrder"];
                    }
                    return entity;
                });

                //ProductsGen entity = new ProductsGen();
                //using(var reader = baseDao.SelectDataReader(sql))
                //{
					//if(reader.Read())
					//{
                        //entity.CategoryID = reader["CategoryID"];
                        //entity.Discontinued = reader["Discontinued"];
                        //entity.ProductID = reader["ProductID"];
                        //entity.ProductName = reader["ProductName"];
                        //entity.QuantityPerUnit = reader["QuantityPerUnit"];
                        //entity.ReorderLevel = reader["ReorderLevel"];
                        //entity.SupplierID = reader["SupplierID"];
                        //entity.UnitPrice = reader["UnitPrice"];
                        //entity.UnitsInStock = reader["UnitsInStock"];
                        //entity.UnitsOnOrder = reader["UnitsOnOrder"];
	                //}
                //}
                //return entity;
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGenDao时，访问OrmByHand时出错", ex);
            }
        }
        */
        /// <summary>
        /// 修改ProductsGen
        /// </summary>
        /// <param name="productsGen">ProductsGen实体对象</param>
        /// <returns>状态代码</returns>
        public int UpdateProductsGen(ProductsGen productsGen)
        {
            try
            {
                Object result = baseDao.Update<ProductsGen>(productsGen);
                int iReturn = Convert.ToInt32(result);

                return iReturn;
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGen时，访问Update时出错", ex);
            }
        }
        /// <summary>
        /// 删除ProductsGen
        /// </summary>
        /// <param name="productsGen">ProductsGen实体对象</param>
        /// <returns>状态代码</returns>
        public int DeleteProductsGen(ProductsGen productsGen)
        {
            try
            {
                Object result = baseDao.Delete<ProductsGen>(productsGen);
                int iReturn = Convert.ToInt32(result);

                return iReturn;
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGen时，访问Delete时出错", ex);
            }
        }
        /// <summary>
        /// 根据主键获取ProductsGen信息
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>ProductsGen信息</returns>
        public ProductsGen FindByPk(int productID )
        {
            try
            {
                return baseDao.GetByKey<ProductsGen>(productID);
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGenDao时，访问FindByPk时出错", ex);
            }
        }
        /// <summary>
        /// 获取所有ProductsGen信息
        /// </summary>
        /// <returns>ProductsGen列表</returns>
        public IList<ProductsGen> GetAll()
        {
            try
            {
                return baseDao.GetAll<ProductsGen>();
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGenDao时，访问GetAll时出错", ex);
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
                String sql = "SELECT count(1) from Products  with (nolock)  ";
                object obj = baseDao.ExecScalar(sql);
                long ret = Convert.ToInt64(obj);
                return ret;
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGenDao时，访问Count时出错", ex);
            }
        }
        /// <summary>
        ///  检索ProductsGen，带翻页
        /// </summary>
        /// <param name="obj">ProductsGen实体对象检索条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageNo">页码</param>
        /// <returns>检索结果</returns>
        public IList<ProductsGen> GetListByPage(ProductsGen obj, int pagesize, int pageNo)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder(200);

                sbSql.Append(@"select CategoryID, Discontinued, ProductID, ProductName, QuantityPerUnit, ReorderLevel, SupplierID, UnitPrice, UnitsInStock, UnitsOnOrder from Products (nolock) ");
                sbSql.Append(" order by ProductID desc ");
                sbSql.Append(string.Format("OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", (pageNo - 1) * pagesize, pagesize));
                IList<ProductsGen> list = baseDao.SelectList<ProductsGen>(sbSql.ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGenDao时，访问GetListByPage时出错", ex);
            }
        }

       /// <summary>
       ///  批量插入ProductsGen
       /// </summary>
       /// <param name="productsGen">ProductsGen实体对象列表</param>
       /// <returns>状态代码</returns>
        public bool BulkInsertProductsGen(IList<ProductsGen> productsGenList)
       	{
            try
            {
                return baseDao.BulkInsert<ProductsGen>(productsGenList);
            }
            catch (Exception ex)
            {
                throw new DalException("调用ProductsGenDao时，访问BulkInsert时出错", ex);
            }
        }

        
    }
}