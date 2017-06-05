using System;
using System.Data;
using Arch.Data.Orm;

namespace CtripDAL.Model.Entity.DataModel
{
    /// <summary>
    /// Categories
    /// </summary>
    [Serializable]
    [Table(Name = "Categories")]
    public partial class CategoriesGen
    {
        /// <summary>
        /// </summary>
        [Column(Name = "CategoryID",ColumnType=DbType.Int32),ID,PK]
        public int CategoryID { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "CategoryName",ColumnType=DbType.String,Length=15)]
        public string CategoryName { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Description",ColumnType=DbType.String,Length=1073741823)]
        public string Description { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Picture",ColumnType=DbType.Binary)]
        public byte[] Picture { get; set; }
    }
}