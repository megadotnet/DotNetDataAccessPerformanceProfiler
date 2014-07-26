using System;

namespace NH
{
	public class Customer : BizObject 
	{
		public Customer() { }
		public Customer( string existingID ) : base( existingID ) { }

		#region persistent properties.

		private string _customerID = string.Empty;
		private string _companyName = string.Empty;
		private string _contactName = string.Empty;
		private string _contactTitle = string.Empty;
		private string _address = string.Empty;
		private string _city = string.Empty;
		private string _region = string.Empty;
		private string _postalCode = string.Empty;
		private string _country = string.Empty;
		private string _phone = string.Empty;
		private string _fax = string.Empty;

		public string CustomerID 
		{
			get { return _customerID; }
			set { _customerID = value; }
		}
		public string CompanyName 
		{
				get { return _companyName; }
			set { _companyName = value; }
		}
		public string ContactName 
		{
			get { return _contactName; }
			set { _contactName = value; }
		}
		public string ContactTitle 
		{
			get { return _contactTitle; }
			set { _contactTitle = value; }
		}
		public string Address 
		{
			get { return _address; }
			set { _address = value; }
		}
		public string City 
		{
			get { return _city; }
			set { _city = value; }
		}
		public string Region 
		{
			get { return _region; }
			set { _region = value; }
		}
		public string PostalCode 
		{
			get { return _postalCode; }
			set { _postalCode = value; }
		}
		public string Country 
		{
			get { return _country; }
			set { _country = value; }
		}
		public string Phone 
		{
			get { return _phone; }
			set { _phone = value; }
		}
		public string Fax 
		{
			get { return _fax; }
			set { _fax = value; }
		}

		#endregion
	}
}
