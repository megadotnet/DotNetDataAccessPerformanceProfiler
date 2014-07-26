// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntLib5DAABAccessorsPerformanceTest.cs" company="Megadotnet">
//   EntLib5DAABAccessorsPerformanceTest
// </copyright>
// <summary>
//   EntLib5DAABAccessorsPerformanceTest
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EntDAAB.Model
{
    using System.Collections.Generic;

    using DBPerformanceTest.Core;
    using DBPerformanceTest.Core.Model;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// EntLib5DAABAccessorsPerformanceTest
    /// </summary>
    public class EntLib5DAABAccessorsPerformanceTest : PerformanceTestBase
    {
        #region Constants and Fields

        /// <summary>
        /// Databases
        /// </summary>
        private static Database _db;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntLib5DAABAccessorsPerformanceTest"/> class.
        /// </summary>
        public EntLib5DAABAccessorsPerformanceTest()
        {
            _db = DatabaseFactory.CreateDatabase("TestDB");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The add.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        public void Add<T>() where T : new()
        {
            IRowMapper<T> mapper = MapBuilder<T>.BuildAllProperties();
            DataAccessor<T> accessor = _db.CreateSqlStringAccessor(this.TearUp()[typeof(T) + "Add"], mapper);
            accessor.Execute();
        }

        /// <summary>
        /// The add category.
        /// </summary>
        public override void AddCategory()
        {
            this.Add<Category>();
        }

        /// <summary>
        /// The add customer.
        /// </summary>
        public override void AddCustomer()
        {
            this.Add<Category>();
        }

        /// <summary>
        /// The add product.
        /// </summary>
        public override void AddProduct()
        {
            this.Add<Product>();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        public void Delete<T>() where T : new()
        {
            IRowMapper<T> mapper = MapBuilder<T>.BuildAllProperties();
            DataAccessor<T> accessor = _db.CreateSqlStringAccessor(this.TearUp()[typeof(T) + "Delete"], mapper);
            accessor.Execute();
        }

        /// <summary>
        /// The delete category.
        /// </summary>
        public override void DeleteCategory()
        {
            this.Delete<Category>();
        }

        /// <summary>
        /// The delete customer.
        /// </summary>
        public override void DeleteCustomer()
        {
            this.Delete<Customer>();
        }

        /// <summary>
        /// The delete product.
        /// </summary>
        public override void DeleteProduct()
        {
            this.Delete<Product>();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        public void GetAll<T>() where T : new()
        {
            IRowMapper<T> mapper = MapBuilder<T>.BuildAllProperties();
            DataAccessor<T> accessor = _db.CreateSqlStringAccessor(this.TearUp()[typeof(T).ToString()], mapper);
            IEnumerable<T> genericDataCollection = accessor.Execute();
        }

        /// <summary>
        /// The get all category.
        /// </summary>
        public override void GetAllCategory()
        {
            this.GetAll<Category>();
        }

        /// <summary>
        /// The get all customer.
        /// </summary>
        public override void GetAllCustomer()
        {
            this.GetAll<Customer>();
        }

        /// <summary>
        /// The get all product.
        /// </summary>
        public override void GetAllProduct()
        {
            this.GetAll<Product>();
        }

        /// <summary>
        /// The get sinlge.
        /// </summary>
        /// <param name="pkid">
        /// The pkid.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void GetSinlge<T>(int pkid) where T : new()
        {
            IRowMapper<T> mapper = MapBuilder<T>.BuildAllProperties();

            // Use a custom parameter mapper and the default output mappings
            IParameterMapper paramMapper = new MyParameterMapper();
            DataAccessor<T> accessor = _db.CreateSqlStringAccessor(
                this.TearUp()[typeof(T) + "Single"], paramMapper, mapper);
            IEnumerable<T> genericDataCollection = accessor.Execute("10");
        }

        /// <summary>
        /// The get sinlge category.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public override void GetSinlgeCategory(int id)
        {
            this.GetSinlge<Product>(id);
        }

        /// <summary>
        /// The get sinlge customer.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public override void GetSinlgeCustomer(int id)
        {
            this.GetSinlge<Customer>(id);
        }

        /// <summary>
        /// The get sinlge product.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public override void GetSinlgeProduct(int id)
        {
            this.GetSinlge<Product>(id);
        }

        /// <summary>
        /// The tear up.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, string> TearUp()
        {
            var entitysqlstatement = new Dictionary<string, string> {
                    { typeof(Product) + "Single", "select * from Products where ProductID = @Id" }, 
                    { typeof(Category) + "Single", "select * from Categories where CategoryID =@Id" }, 
                    { typeof(Customer) + "Single", "select * from Customers where CustomerID = @Id" }, 
                    { typeof(Product).ToString(), "select * from Products" }, 
                    { typeof(Category).ToString(), "select * from Categories" }, 
                    { typeof(Customer).ToString(), "select * from Customers" }, 
                    {
                        typeof(Category) + "Add", 
                        "insert into Categories (CategoryName, Description) values ('category1', 'category1');select SCOPE_IDENTITY()"
                        }, 
                    {
                        typeof(Customer) + "Add", 
                        "insert into Customers (CustomerID, CompanyName, ContactName, Address) values ('test', 'company name', 'contact name', 'address');select SCOPE_IDENTITY()"
                        }, 
                    {
                        typeof(Product) + "Add", 
                        "insert into Products (ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice) values ('test',12 ,3, 'test', 10.5);select SCOPE_IDENTITY()"
                        }, 
                    {
                        typeof(Category) + "Update", 
                        "update Categories set CategoryName = 'testupdate' where CategoryID =10"
                        }, 
                    {
                        typeof(Customer) + "Update", 
                        "update Customers set CompanyName = 'testupdate' where CustomerID = 'test'"
                        }, 
                    { typeof(Product) + "Update", "update Products set UnitPrice = 16.8 where ProductID =10" }, 
                    {
                        typeof(Category) + "Delete", 
                        "delete from Categories where CategoryID =(select max(CategoryID) from Categories)"
                        }, 
                    {
                        typeof(Customer) + "Delete", 
                        "delete from Customers where CustomerID =(select max(CustomerID) from Customers)"
                        }, 
                    {
                        typeof(Product) + "Delete", 
                        "delete from Products where ProductID =(select max(ProductID) from Products)"
                        }
                };
            return entitysqlstatement;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        public void Update<T>() where T : new()
        {
            IRowMapper<T> mapper = MapBuilder<T>.BuildAllProperties();
            DataAccessor<T> accessor = _db.CreateSqlStringAccessor(this.TearUp()[typeof(T) + "Update"], mapper);
            accessor.Execute();
        }

        /// <summary>
        /// The update category.
        /// </summary>
        public override void UpdateCategory()
        {
            this.Update<Category>();
        }

        /// <summary>
        /// The update customer.
        /// </summary>
        public override void UpdateCustomer()
        {
            this.Update<Customer>();
        }

        /// <summary>
        /// The update product.
        /// </summary>
        public override void UpdateProduct()
        {
            this.Update<Product>();
        }

        #endregion
    }
}