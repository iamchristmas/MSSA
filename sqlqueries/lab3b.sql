Use Northwind;
GO
--    1 What is the order number and the date of each order sold by each employee?
Select o.orderid,o.orderdate,e.EmployeeID
From dbo.Orders as o
inner join dbo.Employees as e
    On o.EmployeeID = e.EmployeeID;
GO
--    2 List each territory by region.
Select t.TerritoryDescription,RegionDescription
From Territories as t
inner join dbo.Region as r
    on t.RegionID = r.RegionID;
GO
--    3 What is the supplier name for each product alphabetically by supplier?
Select p.ProductName, s.CompanyName
From dbo.Products as p
inner join dbo.Suppliers as s
    on p.SupplierID = s.SupplierID
Order by s.CompanyName;
GO
-- 4 For every order on May 5, 1998, how many of each item was ordered, and what was the price of the item?
Select o.OrderID,o.OrderDate,od.Quantity,od.UnitPrice
From dbo.Orders as o
inner join dbo.[Order Details] as od
    on o.OrderID = od.OrderID
where o.orderdate = '1998/5/5';
GO
--  5 For every order on May 5, 1998, how many of each item was ordered giving the name of the item, and what was the price of the item?
Select o.OrderID,o.OrderDate,p.ProductName,p.UnitPrice
From dbo.Orders as o
inner join dbo.[Order Details] as od
    on o.OrderID = od.OrderID
inner join dbo.Products as p
    ON od.ProductID = p.ProductID
where o.orderdate = '1998/5/5';
GO
--    6 For every order in May, 1998, what was the customer’s name and the shipper’s name?
Select o.OrderID,o.OrderDate,c.contactname,o.ShipName
From dbo.Orders as o
inner join dbo.customers as c
    on o.CustomerID = c.CustomerID
where o.orderdate = '1998/5/5';
GO
--    7 What is the customer’s name and the employee’s name for every order shipped to France?
SELECT c.ContactName,(e.FirstName + ' ' + e.LastName)as employeeName
FROM dbo.Orders as o
inner join dbo.Customers as c
    ON o.CustomerID = c.CustomerID
inner join dbo.employees as e
    on o.EmployeeID = e.EmployeeID
where o.ShipCountry =  'France';
GO
--    8 List the products by name that were shipped to Germany.
select p.ProductName,o.ShipCountry
from dbo.Orders as o
inner join dbo.[Order Details] od
    on o.OrderID = od.OrderID
inner join dbo.Products as p
    on od.ProductID = p.ProductID
Where o.ShipCountry = 'Germany';
GO


