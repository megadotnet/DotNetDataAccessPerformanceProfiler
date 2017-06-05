using System;
using System.Data;
using Arch.Data.Orm;

namespace CtripDAL.Model.Entity.DataModel
{
    /// <summary>
    /// Customers
    /// </summary>
    [Serializable]
    [Table(Name = "Customers")]
    public partial class CustomersGen
    {
        /// <summary>
        /// </summary>
        [Column(Name = "Address",ColumnType=DbType.String,Length=60)]
        public string Address { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "City",ColumnType=DbType.String,Length=15)]
        public string City { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "CompanyName",ColumnType=DbType.String,Length=40)]
        public string CompanyName { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "ContactName",ColumnType=DbType.String,Length=30)]
        public string ContactName { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "ContactTitle",ColumnType=DbType.String,Length=30)]
        public string ContactTitle { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Country",ColumnType=DbType.String,Length=15)]
        public string Country { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "CustomerID",ColumnType=DbType.StringFixedLength,Length=5),PK]
        public string CustomerID { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Fax",ColumnType=DbType.String,Length=24)]
        public string Fax { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Phone",ColumnType=DbType.String,Length=24)]
        public string Phone { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "PostalCode",ColumnType=DbType.String,Length=10)]
        public string PostalCode { get; set; }
        /// <summary>
        /// </summary>
        [Column(Name = "Region",ColumnType=DbType.String,Length=15)]
        public string Region { get; set; }
    }
}