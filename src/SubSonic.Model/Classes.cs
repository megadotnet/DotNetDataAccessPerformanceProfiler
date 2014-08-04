


using System;
using System.ComponentModel;
using System.Linq;

namespace SubSonic.Model
{
    
    
    
    
    /// <summary>
    /// A class which represents the Customers table in the TestPerformaceDB Database.
    /// This class is queryable through TestPerformaceDBDB.Customer 
    /// </summary>

	public partial class Customer: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Customer(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
		
		private string _CustomerID;
		public string CustomerID { 
		    get{
		        return _CustomerID;
		    } 
		    set{
		        this.OnCustomerIDChanging(value);
                this.SendPropertyChanging();
                this._CustomerID = value;
                this.SendPropertyChanged("CustomerID");
                this.OnCustomerIDChanged();
		    }
		}
		
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
		
		private string _CompanyName;
		public string CompanyName { 
		    get{
		        return _CompanyName;
		    } 
		    set{
		        this.OnCompanyNameChanging(value);
                this.SendPropertyChanging();
                this._CompanyName = value;
                this.SendPropertyChanged("CompanyName");
                this.OnCompanyNameChanged();
		    }
		}
		
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
		
		private string _ContactName;
		public string ContactName { 
		    get{
		        return _ContactName;
		    } 
		    set{
		        this.OnContactNameChanging(value);
                this.SendPropertyChanging();
                this._ContactName = value;
                this.SendPropertyChanged("ContactName");
                this.OnContactNameChanged();
		    }
		}
		
        partial void OnContactTitleChanging(string value);
        partial void OnContactTitleChanged();
		
		private string _ContactTitle;
		public string ContactTitle { 
		    get{
		        return _ContactTitle;
		    } 
		    set{
		        this.OnContactTitleChanging(value);
                this.SendPropertyChanging();
                this._ContactTitle = value;
                this.SendPropertyChanged("ContactTitle");
                this.OnContactTitleChanged();
		    }
		}
		
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
		
		private string _Address;
		public string Address { 
		    get{
		        return _Address;
		    } 
		    set{
		        this.OnAddressChanging(value);
                this.SendPropertyChanging();
                this._Address = value;
                this.SendPropertyChanged("Address");
                this.OnAddressChanged();
		    }
		}
		
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
		
		private string _City;
		public string City { 
		    get{
		        return _City;
		    } 
		    set{
		        this.OnCityChanging(value);
                this.SendPropertyChanging();
                this._City = value;
                this.SendPropertyChanged("City");
                this.OnCityChanged();
		    }
		}
		
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
		
		private string _Region;
		public string Region { 
		    get{
		        return _Region;
		    } 
		    set{
		        this.OnRegionChanging(value);
                this.SendPropertyChanging();
                this._Region = value;
                this.SendPropertyChanged("Region");
                this.OnRegionChanged();
		    }
		}
		
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
		
		private string _PostalCode;
		public string PostalCode { 
		    get{
		        return _PostalCode;
		    } 
		    set{
		        this.OnPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._PostalCode = value;
                this.SendPropertyChanged("PostalCode");
                this.OnPostalCodeChanged();
		    }
		}
		
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
		
		private string _Country;
		public string Country { 
		    get{
		        return _Country;
		    } 
		    set{
		        this.OnCountryChanging(value);
                this.SendPropertyChanging();
                this._Country = value;
                this.SendPropertyChanged("Country");
                this.OnCountryChanged();
		    }
		}
		
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
		
		private string _Phone;
		public string Phone { 
		    get{
		        return _Phone;
		    } 
		    set{
		        this.OnPhoneChanging(value);
                this.SendPropertyChanging();
                this._Phone = value;
                this.SendPropertyChanged("Phone");
                this.OnPhoneChanged();
		    }
		}
		
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
		
		private string _Fax;
		public string Fax { 
		    get{
		        return _Fax;
		    } 
		    set{
		        this.OnFaxChanging(value);
                this.SendPropertyChanging();
                this._Fax = value;
                this.SendPropertyChanged("Fax");
                this.OnFaxChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Categories table in the TestPerformaceDB Database.
    /// This class is queryable through TestPerformaceDBDB.Category 
    /// </summary>

	public partial class Category: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Category(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCategoryIDChanging(int value);
        partial void OnCategoryIDChanged();
		
		private int _CategoryID;
		public int CategoryID { 
		    get{
		        return _CategoryID;
		    } 
		    set{
		        this.OnCategoryIDChanging(value);
                this.SendPropertyChanging();
                this._CategoryID = value;
                this.SendPropertyChanged("CategoryID");
                this.OnCategoryIDChanged();
		    }
		}
		
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
		
		private string _CategoryName;
		public string CategoryName { 
		    get{
		        return _CategoryName;
		    } 
		    set{
		        this.OnCategoryNameChanging(value);
                this.SendPropertyChanging();
                this._CategoryName = value;
                this.SendPropertyChanged("CategoryName");
                this.OnCategoryNameChanged();
		    }
		}
		
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
		
		private string _Description;
		public string Description { 
		    get{
		        return _Description;
		    } 
		    set{
		        this.OnDescriptionChanging(value);
                this.SendPropertyChanging();
                this._Description = value;
                this.SendPropertyChanged("Description");
                this.OnDescriptionChanged();
		    }
		}
		
        partial void OnPictureChanging(byte[] value);
        partial void OnPictureChanged();
		
		private byte[] _Picture;
		public byte[] Picture { 
		    get{
		        return _Picture;
		    } 
		    set{
		        this.OnPictureChanging(value);
                this.SendPropertyChanging();
                this._Picture = value;
                this.SendPropertyChanged("Picture");
                this.OnPictureChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Product> Products
        {
            get
            {
                  var db=new SubSonic.Model.TestPerformaceDBDB();
                  return from items in db.Products
                       where items.CategoryID == _CategoryID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Products table in the TestPerformaceDB Database.
    /// This class is queryable through TestPerformaceDBDB.Product 
    /// </summary>

	public partial class Product: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Product(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
		
		private int _ProductID;
		public int ProductID { 
		    get{
		        return _ProductID;
		    } 
		    set{
		        this.OnProductIDChanging(value);
                this.SendPropertyChanging();
                this._ProductID = value;
                this.SendPropertyChanged("ProductID");
                this.OnProductIDChanged();
		    }
		}
		
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
		
		private string _ProductName;
		public string ProductName { 
		    get{
		        return _ProductName;
		    } 
		    set{
		        this.OnProductNameChanging(value);
                this.SendPropertyChanging();
                this._ProductName = value;
                this.SendPropertyChanged("ProductName");
                this.OnProductNameChanged();
		    }
		}
		
        partial void OnSupplierIDChanging(int? value);
        partial void OnSupplierIDChanged();
		
		private int? _SupplierID;
		public int? SupplierID { 
		    get{
		        return _SupplierID;
		    } 
		    set{
		        this.OnSupplierIDChanging(value);
                this.SendPropertyChanging();
                this._SupplierID = value;
                this.SendPropertyChanged("SupplierID");
                this.OnSupplierIDChanged();
		    }
		}
		
        partial void OnCategoryIDChanging(int? value);
        partial void OnCategoryIDChanged();
		
		private int? _CategoryID;
		public int? CategoryID { 
		    get{
		        return _CategoryID;
		    } 
		    set{
		        this.OnCategoryIDChanging(value);
                this.SendPropertyChanging();
                this._CategoryID = value;
                this.SendPropertyChanged("CategoryID");
                this.OnCategoryIDChanged();
		    }
		}
		
        partial void OnQuantityPerUnitChanging(string value);
        partial void OnQuantityPerUnitChanged();
		
		private string _QuantityPerUnit;
		public string QuantityPerUnit { 
		    get{
		        return _QuantityPerUnit;
		    } 
		    set{
		        this.OnQuantityPerUnitChanging(value);
                this.SendPropertyChanging();
                this._QuantityPerUnit = value;
                this.SendPropertyChanged("QuantityPerUnit");
                this.OnQuantityPerUnitChanged();
		    }
		}
		
        partial void OnUnitPriceChanging(decimal? value);
        partial void OnUnitPriceChanged();
		
		private decimal? _UnitPrice;
		public decimal? UnitPrice { 
		    get{
		        return _UnitPrice;
		    } 
		    set{
		        this.OnUnitPriceChanging(value);
                this.SendPropertyChanging();
                this._UnitPrice = value;
                this.SendPropertyChanged("UnitPrice");
                this.OnUnitPriceChanged();
		    }
		}
		
        partial void OnUnitsInStockChanging(short? value);
        partial void OnUnitsInStockChanged();
		
		private short? _UnitsInStock;
		public short? UnitsInStock { 
		    get{
		        return _UnitsInStock;
		    } 
		    set{
		        this.OnUnitsInStockChanging(value);
                this.SendPropertyChanging();
                this._UnitsInStock = value;
                this.SendPropertyChanged("UnitsInStock");
                this.OnUnitsInStockChanged();
		    }
		}
		
        partial void OnUnitsOnOrderChanging(short? value);
        partial void OnUnitsOnOrderChanged();
		
		private short? _UnitsOnOrder;
		public short? UnitsOnOrder { 
		    get{
		        return _UnitsOnOrder;
		    } 
		    set{
		        this.OnUnitsOnOrderChanging(value);
                this.SendPropertyChanging();
                this._UnitsOnOrder = value;
                this.SendPropertyChanged("UnitsOnOrder");
                this.OnUnitsOnOrderChanged();
		    }
		}
		
        partial void OnReorderLevelChanging(short? value);
        partial void OnReorderLevelChanged();
		
		private short? _ReorderLevel;
		public short? ReorderLevel { 
		    get{
		        return _ReorderLevel;
		    } 
		    set{
		        this.OnReorderLevelChanging(value);
                this.SendPropertyChanging();
                this._ReorderLevel = value;
                this.SendPropertyChanged("ReorderLevel");
                this.OnReorderLevelChanged();
		    }
		}
		
        partial void OnDiscontinuedChanging(bool? value);
        partial void OnDiscontinuedChanged();
		
		private bool? _Discontinued;
		public bool? Discontinued { 
		    get{
		        return _Discontinued;
		    } 
		    set{
		        this.OnDiscontinuedChanging(value);
                this.SendPropertyChanging();
                this._Discontinued = value;
                this.SendPropertyChanged("Discontinued");
                this.OnDiscontinuedChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        public IQueryable<Category> Categories
        {
            get
            {
                  var db=new SubSonic.Model.TestPerformaceDBDB();
                  return from items in db.Categories
                       where items.CategoryID == _CategoryID
                       select items;
            }
        }

        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
}