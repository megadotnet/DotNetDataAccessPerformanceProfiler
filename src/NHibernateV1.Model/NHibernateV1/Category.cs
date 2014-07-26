using System;

namespace NH
{
	public class Category : BizObject
	{
		public Category()
		{}
		public Category(int existingId ) : base( existingId ) { }

		private int categoryID = 0;
		private string categoryName = string.Empty;
		private string description = string.Empty;
		private byte[] picture = null;
		
		public int CategoryID
		{
			get{return categoryID;}
			set{categoryID = value;}
		}
		public string CategoryName
		{
			get{return categoryName;}
			set{categoryName = value;}
		}
		public string Description
		{
			get{return description;}
			set{description = value;}
		}
		public byte[] Picture
		{
			get{return picture;}
			set{picture = value;}
		}
	}
}
