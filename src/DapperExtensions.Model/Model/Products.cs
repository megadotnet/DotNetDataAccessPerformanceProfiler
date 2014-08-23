using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperExtensions.Model
{
    public class Products
    {
        #region Properties

        /// <summary>
        /// Gets or sets CategoryID.
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Discontinued.
        /// </summary>
        public bool Discontinued { get; set; }

        /// <summary>
        /// Gets or sets ProductID.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets QuantityPerUnit.
        /// </summary>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or sets ReorderLevel.
        /// </summary>
        public int ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets SupplierID.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets UnitPrice.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets UnitsInStock.
        /// </summary>
        public int UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets UnitsOnOrder.
        /// </summary>
        public int UnitsOnOrder { get; set; }

        #endregion
    }
}
