--Christopher Smith
--EX4E
USE Northwind;
--Create a report that shows the product name and supplier id for all products supplied by Exotic Liquids, Grandma Kelly’s Homestead, and Tokyo Traders.
Select ProductName,SupplierID
FROM dbo.Products 
where supplierid in (
	select supplierid
	from dbo.Suppliers  
	where 
		SupplierID = 1 or
		SupplierID = 3 or
		SupplierID = 4) 
--Create a report that shows all products by name that are in the Seafood category.
Select ProductName
FROM dbo.Products 
where categoryid = (
	select categoryid
	from dbo.Categories
	where CategoryName like 'Seafood') 
--Create a report that shows all companies by name that sell products in CategoryID 8.
Select CompanyName
FROM dbo.Suppliers
where supplierid in (
Select supplierid
FROM dbo.Products 
where categoryid = 8
	)
--Create a report that shows all companies by name that sell products in the Seafood category.
Select CompanyName
FROM dbo.Suppliers
where supplierid = (
	select supplierid
	from dbo.Categories
	where CategoryName like 'Seafood') 
--Create a report that lists the ten most expensive products.
SELECT TOP 10 ProductName,UnitPrice
FROM (select ProductID, ProductName, UnitPrice
FROM dbo.Products)p
order by UnitPrice desc
--Create a report that shows the date of the last order by all employees.
select  maxorderdate,EmployeeID
FROM (select max(OrderDate) as maxorderdate,EmployeeID
from dbo.Orders
group by EmployeeID) e
USE TSQLV4;
GO