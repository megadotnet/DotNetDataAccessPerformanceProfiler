


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace SubSonic.Model {
	
        /// <summary>
        /// Table: Customers
        /// Primary Key: CustomerID
        /// </summary>

        public class CustomersTable: DatabaseTable {
            
            public CustomersTable(IDataProvider provider):base("Customers",provider){
                ClassName = "Customer";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 5
                });

                Columns.Add(new DatabaseColumn("CompanyName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("ContactName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("ContactTitle", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("Address", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("City", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Region", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("PostalCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("Country", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });

                Columns.Add(new DatabaseColumn("Fax", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });
                    
                
                
            }
            
            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
            				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
           
            public IColumn CompanyName{
                get{
                    return this.GetColumn("CompanyName");
                }
            }
            				
   			public static string CompanyNameColumn{
			      get{
        			return "CompanyName";
      			}
		    }
           
            public IColumn ContactName{
                get{
                    return this.GetColumn("ContactName");
                }
            }
            				
   			public static string ContactNameColumn{
			      get{
        			return "ContactName";
      			}
		    }
           
            public IColumn ContactTitle{
                get{
                    return this.GetColumn("ContactTitle");
                }
            }
            				
   			public static string ContactTitleColumn{
			      get{
        			return "ContactTitle";
      			}
		    }
           
            public IColumn Address{
                get{
                    return this.GetColumn("Address");
                }
            }
            				
   			public static string AddressColumn{
			      get{
        			return "Address";
      			}
		    }
           
            public IColumn City{
                get{
                    return this.GetColumn("City");
                }
            }
            				
   			public static string CityColumn{
			      get{
        			return "City";
      			}
		    }
           
            public IColumn Region{
                get{
                    return this.GetColumn("Region");
                }
            }
            				
   			public static string RegionColumn{
			      get{
        			return "Region";
      			}
		    }
           
            public IColumn PostalCode{
                get{
                    return this.GetColumn("PostalCode");
                }
            }
            				
   			public static string PostalCodeColumn{
			      get{
        			return "PostalCode";
      			}
		    }
           
            public IColumn Country{
                get{
                    return this.GetColumn("Country");
                }
            }
            				
   			public static string CountryColumn{
			      get{
        			return "Country";
      			}
		    }
           
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
            				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
           
            public IColumn Fax{
                get{
                    return this.GetColumn("Fax");
                }
            }
            				
   			public static string FaxColumn{
			      get{
        			return "Fax";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: Categories
        /// Primary Key: CategoryID
        /// </summary>

        public class CategoriesTable: DatabaseTable {
            
            public CategoriesTable(IDataProvider provider):base("Categories",provider){
                ClassName = "Category";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CategoryID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CategoryName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823
                });

                Columns.Add(new DatabaseColumn("Picture", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Binary,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn CategoryID{
                get{
                    return this.GetColumn("CategoryID");
                }
            }
            				
   			public static string CategoryIDColumn{
			      get{
        			return "CategoryID";
      			}
		    }
           
            public IColumn CategoryName{
                get{
                    return this.GetColumn("CategoryName");
                }
            }
            				
   			public static string CategoryNameColumn{
			      get{
        			return "CategoryName";
      			}
		    }
           
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
            				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
           
            public IColumn Picture{
                get{
                    return this.GetColumn("Picture");
                }
            }
            				
   			public static string PictureColumn{
			      get{
        			return "Picture";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: Products
        /// Primary Key: ProductID
        /// </summary>

        public class ProductsTable: DatabaseTable {
            
            public ProductsTable(IDataProvider provider):base("Products",provider){
                ClassName = "Product";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ProductID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ProductName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("SupplierID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CategoryID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("QuantityPerUnit", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("UnitPrice", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("UnitsInStock", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("UnitsOnOrder", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ReorderLevel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Discontinued", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn ProductID{
                get{
                    return this.GetColumn("ProductID");
                }
            }
            				
   			public static string ProductIDColumn{
			      get{
        			return "ProductID";
      			}
		    }
           
            public IColumn ProductName{
                get{
                    return this.GetColumn("ProductName");
                }
            }
            				
   			public static string ProductNameColumn{
			      get{
        			return "ProductName";
      			}
		    }
           
            public IColumn SupplierID{
                get{
                    return this.GetColumn("SupplierID");
                }
            }
            				
   			public static string SupplierIDColumn{
			      get{
        			return "SupplierID";
      			}
		    }
           
            public IColumn CategoryID{
                get{
                    return this.GetColumn("CategoryID");
                }
            }
            				
   			public static string CategoryIDColumn{
			      get{
        			return "CategoryID";
      			}
		    }
           
            public IColumn QuantityPerUnit{
                get{
                    return this.GetColumn("QuantityPerUnit");
                }
            }
            				
   			public static string QuantityPerUnitColumn{
			      get{
        			return "QuantityPerUnit";
      			}
		    }
           
            public IColumn UnitPrice{
                get{
                    return this.GetColumn("UnitPrice");
                }
            }
            				
   			public static string UnitPriceColumn{
			      get{
        			return "UnitPrice";
      			}
		    }
           
            public IColumn UnitsInStock{
                get{
                    return this.GetColumn("UnitsInStock");
                }
            }
            				
   			public static string UnitsInStockColumn{
			      get{
        			return "UnitsInStock";
      			}
		    }
           
            public IColumn UnitsOnOrder{
                get{
                    return this.GetColumn("UnitsOnOrder");
                }
            }
            				
   			public static string UnitsOnOrderColumn{
			      get{
        			return "UnitsOnOrder";
      			}
		    }
           
            public IColumn ReorderLevel{
                get{
                    return this.GetColumn("ReorderLevel");
                }
            }
            				
   			public static string ReorderLevelColumn{
			      get{
        			return "ReorderLevel";
      			}
		    }
           
            public IColumn Discontinued{
                get{
                    return this.GetColumn("Discontinued");
                }
            }
            				
   			public static string DiscontinuedColumn{
			      get{
        			return "Discontinued";
      			}
		    }
           
                    
        }
        
}