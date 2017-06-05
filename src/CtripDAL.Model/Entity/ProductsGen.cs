using System;
using System.Data;
using Arch.Data.Orm;

namespace CtripDAL.Model.Entity.DataModel
{
    /// <summary>
    /// Products
    /// </summary>
    [Serializable]
    [Table(Name = "Products")]
    public partial class ProductsGen
    {
        /// <summary>
        /// </summary>
        [Column(Name = "CategoryID",ColumnType=DbType.Int32)]
        public int? CategoryID { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Discontinued",ColumnType=DbType.Boolean)]
        public bool? Discontinued { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "ProductID",ColumnType=DbType.Int32),ID,PK]
        public int ProductID { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "ProductName",ColumnType=DbType.String,Length=40)]
        public string ProductName { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "QuantityPerUnit",ColumnType=DbType.String,Length=20)]
        public string QuantityPerUnit { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "ReorderLevel",ColumnType=DbType.Int16)]
        public short? ReorderLevel { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "SupplierID",ColumnType=DbType.Int32)]
        public int? SupplierID { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "UnitPrice",ColumnType=DbType.Decimal)]
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "UnitsInStock",ColumnType=DbType.Int16)]
        public short? UnitsInStock { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "UnitsOnOrder",ColumnType=DbType.Int16)]
        public short? UnitsOnOrder { get; set; }
    }
}