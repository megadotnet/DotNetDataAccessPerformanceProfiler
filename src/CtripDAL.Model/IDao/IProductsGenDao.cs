using System;
using System.Collections.Generic;
using CtripDAL.Model.Entity.DataModel;

namespace CtripDAL.Model.Interface.IDao
{
        public partial interface IProductsGenDao
        {

        /// <summary>
        ///  插入ProductsGen
        /// </summary>
        /// <param name="productsGen">ProductsGen实体对象</param>
        /// <returns>状态代码</returns>
		int InsertProductsGen(ProductsGen productsGen);
        /// <summary>
        /// 修改ProductsGen
        /// </summary>
        /// <param name="productsGen">ProductsGen实体对象</param>
        /// <returns>状态代码</returns>
        int UpdateProductsGen(ProductsGen productsGen);
        /// <summary>
        /// 删除ProductsGen
        /// </summary>
        /// <param name="productsGen">ProductsGen实体对象</param>
        /// <returns>状态代码</returns>
        int DeleteProductsGen(ProductsGen productsGen);
        /// <summary>
        /// 根据主键获取ProductsGen信息
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>ProductsGen信息</returns>
        ProductsGen FindByPk(int productID);
        /// <summary>
        /// 获取所有ProductsGen信息
        /// </summary>
        /// <returns>ProductsGen列表</returns>
        IList<ProductsGen> GetAll();
        /// <summary>
        /// 取得总记录数
        /// </summary>
        /// <returns>记录数</returns>
        long Count();
        /// <summary>
        ///  批量插入ProductsGen
        /// </summary>
        /// <param name="productsGen">ProductsGen实体对象列表</param>
        /// <returns>状态代码</returns>
        bool BulkInsertProductsGen(IList<ProductsGen> productsGenList);
        /// <summary>
        ///  检索ProductsGen，带翻页
        /// </summary>
        /// <param name="obj">ProductsGen实体对象检索条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageNo">页码</param>
        /// <returns>检索结果</returns>
        IList<ProductsGen> GetListByPage(ProductsGen obj, int pagesize, int pageNo);


        }
}