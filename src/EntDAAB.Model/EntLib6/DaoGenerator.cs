

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using DG.Common;

namespace DataGenerator
{
public class CustomersDao

{
				private const string CustomerIDColumn ="CustomerID";
				private const string CompanyNameColumn ="CompanyName";
				private const string ContactNameColumn ="ContactName";
				private const string ContactTitleColumn ="ContactTitle";
				private const string AddressColumn ="Address";
				private const string CityColumn ="City";
				private const string RegionColumn ="Region";
				private const string PostalCodeColumn ="PostalCode";
				private const string CountryColumn ="Country";
				private const string PhoneColumn ="Phone";
				private const string FaxColumn ="Fax";
				private static readonly string[] ColumnCollections = new[] { CustomerIDColumn,CompanyNameColumn,ContactNameColumn,ContactTitleColumn,AddressColumn,CityColumn,RegionColumn,PostalCodeColumn,CountryColumn,PhoneColumn,FaxColumn};
        private readonly string _columnCollectionSelectString = string.Join(",", ColumnCollections);
        private static readonly string[] KeyColumns = new string[] { "CustomerID" };
        private static readonly string WhereClause = KeyColumns.JoinFormat(" AND ", "{0} = @{0}");
		private readonly Database _database;
      
        public CustomersDao()
        {
            _database = DatabaseFactory.CreateDatabase("TestDB");
        }

        public CustomersDao(Database database)
        {
            _database = database;
        }
		
		private string GetSortText(SortDefinitions sortDefinitions)
		{
			string sortDefinition;
            if(sortDefinitions!=null && sortDefinitions.SoftItems.Count>0)
            {
                sortDefinition = string.Join(" , ", sortDefinitions.SoftItems.Select(p=> string.Format("{0} {1}", p.ColumnName , (p.SortOrder==SortOrder.None)?"":p.SortOrder.ToString())));
				
				sortDefinition = string.Format(" ORDER BY {0}", sortDefinition);				
            }
			else
			{
				 sortDefinition = "ORDER BY " + string.Join(",", KeyColumns);
			}		
			return sortDefinition;
		}
		
		public List<Customers> GetCustomers( SortDefinitions sortDefinitions , int startIndex, int pageSize)
        {
		    string sqlText;
			var sortText = GetSortText(sortDefinitions);
			if(startIndex>-1 && pageSize>0)
			{
			  sqlText = GetPagedQuery(sortText, startIndex, pageSize);
			}
			else
			 sqlText = GetCustomersSQL();

            return _database.CreateSqlStringAccessor<Customers>(sqlText).Execute().ToList();
        }
		
		
		

        public List<Customers> GetCustomers()
        {

            return _database.CreateSqlStringAccessor<Customers>(GetCustomersSQL()).Execute().ToList();
        }

        		public Customers GetCustomersByKey(Customers customers)
        {
            return _database.CreateSqlStringAccessor<Customers>(GetCustomersByKeySQL(), new CustomersSelectKeyParameterMapper()).Execute(customers.CustomerID).SingleOrDefault();
		}
		
		private string GetCustomersByKeySQL()
        {
            var sql = string.Format(@"SELECT  {0}
                            FROM 
                                Customers
                            WHERE
                                {1}
                                       ", _columnCollectionSelectString, WhereClause);
            return sql;
        }
		
		public class CustomersSelectKeyParameterMapper : IParameterMapper
        {
            public void AssignParameters(DbCommand command, object[] parameterValues)
            {
                for (int i = 0; i < KeyColumns.Count(); i++)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = string.Format("@{0}", KeyColumns[i]);
                    parameter.Value = parameterValues[i];
                    command.Parameters.Add(parameter);
                }
               

            }
		}
		        public long Insert(Customers customers)
        { 			
			var command = _database.GetSqlStringCommand(InsertCustomersSQL());
		               AddInsertParameters(command, customers);
            _database.ExecuteNonQuery(command);
						return 1;
			        }

        public void Update(Customers customers)
        {
            var command = _database.GetSqlStringCommand(UpdateCustomersSQL());
            AddUpdateParameters(command, customers);
            _database.ExecuteNonQuery(command);
        }

        public void Delete(Customers customers)
        {
            var command = _database.GetSqlStringCommand(DeleteCustomersSQL());
						AddKeyColumns(command, customers.CustomerID);
			            _database.ExecuteNonQuery(command);
        }
				private void AddKeyColumns(DbCommand command, params  object[] paramValues)
        {
            for (int i = 0; i < KeyColumns.Count(); i++)
            {
                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = string.Format("@{0}", KeyColumns[i]);
                parameter.Value = paramValues[i];
                command.Parameters.Add(parameter);
            }
           
        }
				
		private void AddInsertParameters(DbCommand command, Customers customers)
        {
            DbParameter parameter = null;
        			    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@CustomerIDColumn);
			            parameter.Value = customers.CustomerID;
            			command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@CompanyNameColumn);
						parameter.Value = (object)customers.CompanyName??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@ContactNameColumn);
						parameter.Value = (object)customers.ContactName??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@ContactTitleColumn);
						parameter.Value = (object)customers.ContactTitle??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@AddressColumn);
						parameter.Value = (object)customers.Address??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@CityColumn);
						parameter.Value = (object)customers.City??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@RegionColumn);
						parameter.Value = (object)customers.Region??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@PostalCodeColumn);
						parameter.Value = (object)customers.PostalCode??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@CountryColumn);
						parameter.Value = (object)customers.Country??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@PhoneColumn);
						parameter.Value = (object)customers.Phone??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@FaxColumn);
						parameter.Value = (object)customers.Fax??DBNull.Value;
						command.Parameters.Add(parameter);
		
			           
        }		
		
		private void AddUpdateParameters(DbCommand command, Customers customers)
        {
		            AddInsertParameters(command, customers);
        }
				
		private string GetCustomersSQL()
        {
            var sql = string.Format(@" SELECT  {0} 
                                          FROM 
                                                Customers
                                       ", _columnCollectionSelectString);
            return sql;
        }      

		private string GetPagedQuery( string sqlText, int startIndex , int pageSize)
		{
		  	var endIndex = startIndex + pageSize;
          	startIndex = startIndex + 1;

          	var sql = string.Format(@"SELECT TOP {0} {4} 
						FROM ( 
							SELECT    {4} , ROW_NUMBER() OVER ({1}) AS ROW 
						    FROM  Customers ) AS WithRowNumber
					    WHERE
                            ROW BETWEEN {2} AND {3} {1}", pageSize, sqlText, startIndex, endIndex, _columnCollectionSelectString);

          	return sql;		    
		}
		
        private string InsertCustomersSQL()
        {
			var nonIdentColumns= ColumnCollections;
		 	var sql = string.Format(@" INSERT INTO
                            Customers (
                              {0}
                            )
                            VALUES
                            (
                                {1}
                            ) ;
                                       ", nonIdentColumns.JoinFormat(",","{0}"), nonIdentColumns.JoinFormat(",", "@{0}"));
                        return sql;
        }

        private string UpdateCustomersSQL()
        {
		 	var sql = string.Format(@" UPDATE
                                 Customers
                            SET
                               {1}
                            WHERE 
                                  {0}
                                       ", WhereClause, ColumnCollections.Except(KeyColumns).ToArray().JoinFormat(" , ", "{0} = @{0}"));
            return sql;
        }

        private string DeleteCustomersSQL()
        { 
		 	var sql = string.Format(@" DELETE  FROM
                              Customers
                            WHERE 
                                {0}           
                                       ", WhereClause);
            return sql;
        }
  
	}
public class CategoriesDao

{
		 
			private const string IdentityColumn = "CategoryID"; 
				private const string CategoryNameColumn ="CategoryName";
				private const string DescriptionColumn ="Description";
				private const string PictureColumn ="Picture";
				private static readonly string[] ColumnCollections = new[] { IdentityColumn,CategoryNameColumn,DescriptionColumn,PictureColumn};
        private readonly string _columnCollectionSelectString = string.Join(",", ColumnCollections);
        private static readonly string[] KeyColumns = new string[] { "CategoryID" };
        private static readonly string WhereClause = KeyColumns.JoinFormat(" AND ", "{0} = @{0}");
		private readonly Database _database;
      
        public CategoriesDao()
        {
            _database = DatabaseFactory.CreateDatabase("TestDB");
        }

        public CategoriesDao(Database database)
        {
            _database = database;
        }
		
		private string GetSortText(SortDefinitions sortDefinitions)
		{
			string sortDefinition;
            if(sortDefinitions!=null && sortDefinitions.SoftItems.Count>0)
            {
                sortDefinition = string.Join(" , ", sortDefinitions.SoftItems.Select(p=> string.Format("{0} {1}", p.ColumnName , (p.SortOrder==SortOrder.None)?"":p.SortOrder.ToString())));
				
				sortDefinition = string.Format(" ORDER BY {0}", sortDefinition);				
            }
			else
			{
				 sortDefinition = "ORDER BY " + string.Join(",", KeyColumns);
			}		
			return sortDefinition;
		}
		
		public List<Categories> GetCategories( SortDefinitions sortDefinitions , int startIndex, int pageSize)
        {
		    string sqlText;
			var sortText = GetSortText(sortDefinitions);
			if(startIndex>-1 && pageSize>0)
			{
			  sqlText = GetPagedQuery(sortText, startIndex, pageSize);
			}
			else
			 sqlText = GetCategoriesSQL();

            return _database.CreateSqlStringAccessor<Categories>(sqlText).Execute().ToList();
        }
		
		
		

        public List<Categories> GetCategories()
        {

            return _database.CreateSqlStringAccessor<Categories>(GetCategoriesSQL()).Execute().ToList();
        }

                public Categories GetCategoriesById(object id)
        {
            return _database.CreateSqlStringAccessor<Categories>(GetCategoriesByIdSQL(), new CategoriesSelectIdParameterMapper()).Execute(id).SingleOrDefault();
        }
		
        private class CategoriesSelectIdParameterMapper : IParameterMapper
        {
		   public void AssignParameters(DbCommand command, object[] parameterValues)
            {
				var parameter = command.CreateParameter();
                parameter.ParameterName = string.Format("@{0}", IdentityColumn);
                parameter.Value = parameterValues[0];
                command.Parameters.Add(parameter);
			}
        }
		
		private string GetCategoriesByIdSQL()
        {
            var sql = string.Format(@"SELECT  {0}
                            FROM 
                                Categories
                            WHERE
                                {1}
                                       ", _columnCollectionSelectString, string.Format("{0} = @{0}",IdentityColumn));
            return sql;
        }
				public Categories GetCategoriesByKey(Categories categories)
        {
            return _database.CreateSqlStringAccessor<Categories>(GetCategoriesByKeySQL(), new CategoriesSelectKeyParameterMapper()).Execute(categories.CategoryID).SingleOrDefault();
		}
		
		private string GetCategoriesByKeySQL()
        {
            var sql = string.Format(@"SELECT  {0}
                            FROM 
                                Categories
                            WHERE
                                {1}
                                       ", _columnCollectionSelectString, WhereClause);
            return sql;
        }
		
		public class CategoriesSelectKeyParameterMapper : IParameterMapper
        {
            public void AssignParameters(DbCommand command, object[] parameterValues)
            {
                for (int i = 0; i < KeyColumns.Count(); i++)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = string.Format("@{0}", KeyColumns[i]);
                    parameter.Value = parameterValues[i];
                    command.Parameters.Add(parameter);
                }
               

            }
		}
		        public long Insert(Categories categories)
        { 			
			var command = _database.GetSqlStringCommand(InsertCategoriesSQL());
		   			var parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}", IdentityColumn);
            parameter.DbType = DbType.Int64;
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);
			            AddInsertParameters(command, categories);
            _database.ExecuteNonQuery(command);
			            var id =Convert.ToInt64( parameter.Value);
            return id;
			        }

        public void Update(Categories categories)
        {
            var command = _database.GetSqlStringCommand(UpdateCategoriesSQL());
            AddUpdateParameters(command, categories);
            _database.ExecuteNonQuery(command);
        }

        public void Delete(Categories categories)
        {
            var command = _database.GetSqlStringCommand(DeleteCategoriesSQL());
			            AddIdentityColumn(command, categories);
			            _database.ExecuteNonQuery(command);
        }
				
		private void AddInsertParameters(DbCommand command, Categories categories)
        {
            DbParameter parameter = null;
        			    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@CategoryNameColumn);
						parameter.Value = (object)categories.CategoryName??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@DescriptionColumn);
						parameter.Value = (object)categories.Description??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@PictureColumn);
						parameter.Value = (object)categories.Picture??DBNull.Value;
						command.Parameters.Add(parameter);
		
			           
        }		
		
		private void AddUpdateParameters(DbCommand command, Categories categories)
        {
		            AddIdentityColumn(command, categories);
		            AddInsertParameters(command, categories);
        }
				
        private void AddIdentityColumn(DbCommand command, Categories categories)
        {
		  
            var parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}", IdentityColumn);
            parameter.Value = categories.CategoryID;
            command.Parameters.Add(parameter);

		}
				
		private string GetCategoriesSQL()
        {
            var sql = string.Format(@" SELECT  {0} 
                                          FROM 
                                                Categories
                                       ", _columnCollectionSelectString);
            return sql;
        }      

		private string GetPagedQuery( string sqlText, int startIndex , int pageSize)
		{
		  	var endIndex = startIndex + pageSize;
          	startIndex = startIndex + 1;

          	var sql = string.Format(@"SELECT TOP {0} {4} 
						FROM ( 
							SELECT    {4} , ROW_NUMBER() OVER ({1}) AS ROW 
						    FROM  Categories ) AS WithRowNumber
					    WHERE
                            ROW BETWEEN {2} AND {3} {1}", pageSize, sqlText, startIndex, endIndex, _columnCollectionSelectString);

          	return sql;		    
		}
		
        private string InsertCategoriesSQL()
        {
			var nonIdentColumns= ColumnCollections.Except(new[]{IdentityColumn}).ToList();
		 	var sql = string.Format(@" INSERT INTO
                            Categories (
                              {0}
                            )
                            VALUES
                            (
                                {1}
                            ) ;
                                       ", nonIdentColumns.JoinFormat(",","{0}"), nonIdentColumns.JoinFormat(",", "@{0}"));
                        sql = string.Format("{0} SET @{1} = SCOPE_IDENTITY()", sql, IdentityColumn);
                        return sql;
        }

        private string UpdateCategoriesSQL()
        {
		 	var sql = string.Format(@" UPDATE
                                 Categories
                            SET
                               {1}
                            WHERE 
                                  {0}
                                       ", WhereClause, ColumnCollections.Except(KeyColumns).ToArray().JoinFormat(" , ", "{0} = @{0}"));
            return sql;
        }

        private string DeleteCategoriesSQL()
        { 
		 	var sql = string.Format(@" DELETE  FROM
                              Categories
                            WHERE 
                                {0}           
                                       ", string.Format("{0}=@{0}",IdentityColumn));
            return sql;
        }
  
	}
public class ProductsDao

{
		 
			private const string IdentityColumn = "ProductID"; 
				private const string ProductNameColumn ="ProductName";
				private const string SupplierIDColumn ="SupplierID";
				private const string CategoryIDColumn ="CategoryID";
				private const string QuantityPerUnitColumn ="QuantityPerUnit";
				private const string UnitPriceColumn ="UnitPrice";
				private const string UnitsInStockColumn ="UnitsInStock";
				private const string UnitsOnOrderColumn ="UnitsOnOrder";
				private const string ReorderLevelColumn ="ReorderLevel";
				private const string DiscontinuedColumn ="Discontinued";
				private static readonly string[] ColumnCollections = new[] { IdentityColumn,ProductNameColumn,SupplierIDColumn,CategoryIDColumn,QuantityPerUnitColumn,UnitPriceColumn,UnitsInStockColumn,UnitsOnOrderColumn,ReorderLevelColumn,DiscontinuedColumn};
        private readonly string _columnCollectionSelectString = string.Join(",", ColumnCollections);
        private static readonly string[] KeyColumns = new string[] { "ProductID" };
        private static readonly string WhereClause = KeyColumns.JoinFormat(" AND ", "{0} = @{0}");
		private readonly Database _database;
      
        public ProductsDao()
        {
            _database = DatabaseFactory.CreateDatabase("TestDB");
        }

        public ProductsDao(Database database)
        {
            _database = database;
        }
		
		private string GetSortText(SortDefinitions sortDefinitions)
		{
			string sortDefinition;
            if(sortDefinitions!=null && sortDefinitions.SoftItems.Count>0)
            {
                sortDefinition = string.Join(" , ", sortDefinitions.SoftItems.Select(p=> string.Format("{0} {1}", p.ColumnName , (p.SortOrder==SortOrder.None)?"":p.SortOrder.ToString())));
				
				sortDefinition = string.Format(" ORDER BY {0}", sortDefinition);				
            }
			else
			{
				 sortDefinition = "ORDER BY " + string.Join(",", KeyColumns);
			}		
			return sortDefinition;
		}
		
		public List<Products> GetProducts( SortDefinitions sortDefinitions , int startIndex, int pageSize)
        {
		    string sqlText;
			var sortText = GetSortText(sortDefinitions);
			if(startIndex>-1 && pageSize>0)
			{
			  sqlText = GetPagedQuery(sortText, startIndex, pageSize);
			}
			else
			 sqlText = GetProductsSQL();

            return _database.CreateSqlStringAccessor<Products>(sqlText).Execute().ToList();
        }
		
		
		

        public List<Products> GetProducts()
        {

            return _database.CreateSqlStringAccessor<Products>(GetProductsSQL()).Execute().ToList();
        }

                public Products GetProductsById(object id)
        {
            return _database.CreateSqlStringAccessor<Products>(GetProductsByIdSQL(), new ProductsSelectIdParameterMapper()).Execute(id).SingleOrDefault();
        }
		
        private class ProductsSelectIdParameterMapper : IParameterMapper
        {
		   public void AssignParameters(DbCommand command, object[] parameterValues)
            {
				var parameter = command.CreateParameter();
                parameter.ParameterName = string.Format("@{0}", IdentityColumn);
                parameter.Value = parameterValues[0];
                command.Parameters.Add(parameter);
			}
        }
		
		private string GetProductsByIdSQL()
        {
            var sql = string.Format(@"SELECT  {0}
                            FROM 
                                Products
                            WHERE
                                {1}
                                       ", _columnCollectionSelectString, string.Format("{0} = @{0}",IdentityColumn));
            return sql;
        }
				public Products GetProductsByKey(Products products)
        {
            return _database.CreateSqlStringAccessor<Products>(GetProductsByKeySQL(), new ProductsSelectKeyParameterMapper()).Execute(products.ProductID).SingleOrDefault();
		}
		
		private string GetProductsByKeySQL()
        {
            var sql = string.Format(@"SELECT  {0}
                            FROM 
                                Products
                            WHERE
                                {1}
                                       ", _columnCollectionSelectString, WhereClause);
            return sql;
        }
		
		public class ProductsSelectKeyParameterMapper : IParameterMapper
        {
            public void AssignParameters(DbCommand command, object[] parameterValues)
            {
                for (int i = 0; i < KeyColumns.Count(); i++)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = string.Format("@{0}", KeyColumns[i]);
                    parameter.Value = parameterValues[i];
                    command.Parameters.Add(parameter);
                }
               

            }
		}
		        public long Insert(Products products)
        { 			
			var command = _database.GetSqlStringCommand(InsertProductsSQL());
		   			var parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}", IdentityColumn);
            parameter.DbType = DbType.Int64;
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);
			            AddInsertParameters(command, products);
            _database.ExecuteNonQuery(command);
			            var id =Convert.ToInt64( parameter.Value);
            return id;
			        }

        public void Update(Products products)
        {
            var command = _database.GetSqlStringCommand(UpdateProductsSQL());
            AddUpdateParameters(command, products);
            _database.ExecuteNonQuery(command);
        }

        public void Delete(Products products)
        {
            var command = _database.GetSqlStringCommand(DeleteProductsSQL());
			            AddIdentityColumn(command, products);
			            _database.ExecuteNonQuery(command);
        }
				
		private void AddInsertParameters(DbCommand command, Products products)
        {
            DbParameter parameter = null;
        			    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@ProductNameColumn);
						parameter.Value = (object)products.ProductName??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@SupplierIDColumn);
						parameter.Value = (object)products.SupplierID??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@CategoryIDColumn);
						parameter.Value = (object)products.CategoryID??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@QuantityPerUnitColumn);
						parameter.Value = (object)products.QuantityPerUnit??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@UnitPriceColumn);
						parameter.Value = (object)products.UnitPrice??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@UnitsInStockColumn);
						parameter.Value = (object)products.UnitsInStock??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@UnitsOnOrderColumn);
						parameter.Value = (object)products.UnitsOnOrder??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@ReorderLevelColumn);
						parameter.Value = (object)products.ReorderLevel??DBNull.Value;
						command.Parameters.Add(parameter);
		
					    parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}",@DiscontinuedColumn);
						parameter.Value = (object)products.Discontinued??DBNull.Value;
						command.Parameters.Add(parameter);
		
			           
        }		
		
		private void AddUpdateParameters(DbCommand command, Products products)
        {
		            AddIdentityColumn(command, products);
		            AddInsertParameters(command, products);
        }
				
        private void AddIdentityColumn(DbCommand command, Products products)
        {
		  
            var parameter = command.CreateParameter();
            parameter.ParameterName = string.Format("@{0}", IdentityColumn);
            parameter.Value = products.ProductID;
            command.Parameters.Add(parameter);

		}
				
		private string GetProductsSQL()
        {
            var sql = string.Format(@" SELECT  {0} 
                                          FROM 
                                                Products
                                       ", _columnCollectionSelectString);
            return sql;
        }      

		private string GetPagedQuery( string sqlText, int startIndex , int pageSize)
		{
		  	var endIndex = startIndex + pageSize;
          	startIndex = startIndex + 1;

          	var sql = string.Format(@"SELECT TOP {0} {4} 
						FROM ( 
							SELECT    {4} , ROW_NUMBER() OVER ({1}) AS ROW 
						    FROM  Products ) AS WithRowNumber
					    WHERE
                            ROW BETWEEN {2} AND {3} {1}", pageSize, sqlText, startIndex, endIndex, _columnCollectionSelectString);

          	return sql;		    
		}
		
        private string InsertProductsSQL()
        {
			var nonIdentColumns= ColumnCollections.Except(new[]{IdentityColumn}).ToList();
		 	var sql = string.Format(@" INSERT INTO
                            Products (
                              {0}
                            )
                            VALUES
                            (
                                {1}
                            ) ;
                                       ", nonIdentColumns.JoinFormat(",","{0}"), nonIdentColumns.JoinFormat(",", "@{0}"));
                        sql = string.Format("{0} SET @{1} = SCOPE_IDENTITY()", sql, IdentityColumn);
                        return sql;
        }

        private string UpdateProductsSQL()
        {
		 	var sql = string.Format(@" UPDATE
                                 Products
                            SET
                               {1}
                            WHERE 
                                  {0}
                                       ", WhereClause, ColumnCollections.Except(KeyColumns).ToArray().JoinFormat(" , ", "{0} = @{0}"));
            return sql;
        }

        private string DeleteProductsSQL()
        { 
		 	var sql = string.Format(@" DELETE  FROM
                              Products
                            WHERE 
                                {0}           
                                       ", string.Format("{0}=@{0}",IdentityColumn));
            return sql;
        }
  
	}
}
