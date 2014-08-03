delete from dbo.Categories
truncate table dbo.Products
truncate table dbo.Customers

--add 1000 recorders
declare @i int
declare @char varchar(1000)
set @i=0
while @i<1000
begin
set @char = convert(varchar(1000),@i)
insert into Categories (CategoryName, [Description])
 values ('category' + @char,'category' + @char)

insert into Customers (CustomerID, CompanyName, ContactName, [Address]) 
values (@char, 'company name'+@char, 'contact name'+@char, 'address'+@char)

insert into Products (ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice) 
values ('testpro'+@char,1,3,'test'+@char,1.1)
set @i=@i+1
end

select count(*) from dbo.Categories
select count(*) from dbo.Products
select count(*) from dbo.Customers