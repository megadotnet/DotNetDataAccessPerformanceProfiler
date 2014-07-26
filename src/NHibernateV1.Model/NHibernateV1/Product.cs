using System;

namespace NH
{
	public class Product : BizObject 
	{
		public Product() : base() { }
		public Product( int existingID ) : base( existingID ) { }

		#region persistent properties
		private int _productID = 0;
		private string _productName = string.Empty;
		private int _supplierID = 0;
		private int _categoryID = 0;
		private string _quantityPerUnit = string.Empty;
		private decimal _unitPrice = 0;
		private int _unitsInStock = 0;
		private int _unitsOnOrder = 0;
		private int _reorderLevel = 0;
		private bool _discontinued = false;

		public int ProductID 
		{
			get { return _productID; }
			set { _productID = value; }
		}
		public string ProductName 
		{
			get { return _productName; }
			set { _productName = value; }
		}
		public int SupplierID 
		{ 
			get { return _supplierID; }
			set { _supplierID = value; }
		}

		public int CategoryID 
		{ 
			get { return _categoryID; }
			set { _categoryID = value; }
		}

		public string QuantityPerUnit 
		{
			get { return _quantityPerUnit; }
			set { _quantityPerUnit = value; }
		}
		public decimal UnitPrice 
		{
			get { return _unitPrice; }
			set { _unitPrice = value; }
		}
		public int UnitsInStock 
		{
			get { return _unitsInStock; }
			set { _unitsInStock = value; }
		}
		public int UnitsOnOrder 
		{
			get { return _unitsOnOrder; }
			set { _unitsOnOrder = value; }
		}
		public int ReorderLevel 
		{
			get { return _reorderLevel; }
			set { _reorderLevel = value; }
		}
		public bool Discontinued 
		{
			get { return _discontinued; }
			set { _discontinued = value; }
		}

		#endregion
	}
}
