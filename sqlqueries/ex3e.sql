USE Northwind;
GO

--1 .Using SQLite and the Northwind database, create a line item report that contains a line for each
--product in the order with the following columns: the order id, the product id, the unit price, the
--quantity sold, the line item price, and the percent of that line item constitutes of the total amount of
--the order.
SELECT	OrderID,
		ProductID,
		UnitPrice,
		quantity,
		SUM(Quantity * UnitPrice)as linetotal, 
		SUM(quantity*unitprice) / (SUM(Quantity * UnitPrice)Over(partition by orderid)) * 100 as PctOfTotalOrder
FROM	dbo.[Order Details]
Group by OrderID,ProductID, UnitPrice,Quantity;
GO
--2. I want to know the unique (distinct) cities, regions, and postal codes: (a) where we have both customers
--and employees, (b) where we have customers but no employees AND both customers ad employees,
--and (c) where we have employees but no customers AND both customers and employees. Write three
--queries, using inner and outer joins. Report the results of the queries. There is no need for any further
--reporting.
select  distinct c.PostalCode,
		c.City,
		c.Region
from dbo.Customers as c
inner join dbo.Employees as e on c.City = e.City;

select	distinct c.City,
		c.Region,
		c.PostalCode
from dbo.Customers as c
left join dbo.Employees as e on c.City = e.City;

select	distinct c.City,
		c.Region,
		c.PostalCode
from dbo.Customers as c
right join dbo.Employees as e on c.City = e.City;

--3. Using subqueries, create a report that lists the ten most expensive products.
Select top 10 *
FROM	(select ProductID,ProductName,UnitPrice
		from dbo.Products
		) as s
order by s.UnitPrice desc
--4. Using subqueries, create a report that shows the date of the last order by all employees.
 select distinct oa.EmployeeID,oa.OrderDate
 from dbo.Orders as oa
 WHERE oa.OrderDate IN 
 (SELECT MAX(OrderDate) FROM  dbo.Orders as o WHERE oa.EmployeeID = o.EmployeeID GROUP BY o.EmployeeID) 

 --5. Using subqueries, create a line item report that contains a line for each product in the order with the
 --following columns: the order id, the product id, the unit price, the quantity sold, the line item price,
 -- and the percent of that line item constitutes of the total amount of the order.

SELECT	od.OrderID,
		od.ProductID,
		od.UnitPrice,
		od.quantity,
		SUM(od.Quantity * od.UnitPrice) as linetotal,
		CAST((od.Quantity*od.UnitPrice) / (SELECT SUM(ods.Quantity*ods.UnitPrice) * 1/100
			FROM dbo.[Order Details] AS ods
			WHERE od.orderid = ods.orderid)  
		AS NUMERIC(8,2)) TotalPercentage
FROM	dbo.[Order Details] as od
group by od.orderid,od.ProductID,od.UnitPrice, od.Quantity
