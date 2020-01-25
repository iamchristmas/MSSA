USE Northwind;
GO
--Question 1.
Select * 
From region;
GO
--Question 2.
select *
from Territories;
GO
--Question 3.
Select *
From Territories
Where RegionID = 4;
GO
--Question 4.
Select *
From Territories
Where Territories.RegionID = 4;
GO
--Question 5.
Select TerritoryID,TerritoryDescription as southerncities
From Territories
Where Territories.RegionID = 4
GO
--Question 6.
Select ContactName,Phone,City
From Customers;
GO
--Question 7.
select * 
From Products
Where UnitsInStock = 0;
GO
--Question 8.
Select TOP 10 unitsinstock, ProductName
From Products
Where UnitsInStock > 0
Order By UnitsInStock asc;
GO
--Question 9.
select top 5 UnitPrice,ProductName 
From Products
order by unitprice desc;
GO
--Question 10.
select  COUNT(DISTINCT Products.ProductID) AS numberofproducts,
		COUNT(DISTINCT Customers.CustomerID) AS numberofcustomers,
		COUNT(DISTINCT Suppliers.SupplierID) AS numberofsuppliers
from products,customers,Suppliers;