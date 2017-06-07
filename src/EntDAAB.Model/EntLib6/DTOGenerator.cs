

using System;

namespace DataGenerator
{
public class Customers
{
  	public string CustomerID {get;set;}

	public string CompanyName {get;set;}

	public string ContactName {get;set;}

	public string ContactTitle {get;set;}

	public string Address {get;set;}

	public string City {get;set;}

	public string Region {get;set;}

	public string PostalCode {get;set;}

	public string Country {get;set;}

	public string Phone {get;set;}

	public string Fax {get;set;}

}
public class Categories
{
  	public int CategoryID {get;set;}

	public string CategoryName {get;set;}

	public string Description {get;set;}

	public byte[] Picture {get;set;}

}
public class Products
{
  	public int ProductID {get;set;}

	public string ProductName {get;set;}

	public int? SupplierID {get;set;}

	public int? CategoryID {get;set;}

	public string QuantityPerUnit {get;set;}

	public decimal? UnitPrice {get;set;}

	public short? UnitsInStock {get;set;}

	public short? UnitsOnOrder {get;set;}

	public short? ReorderLevel {get;set;}

	public bool? Discontinued {get;set;}

}
}