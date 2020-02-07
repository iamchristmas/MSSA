--Exercise 4G
--Christopher Smith

--1
select cust,
	Count(productid) distProduct,
	orderyear
from(
	Select
		distinct od.productid,
		year(o.orderdate),
		o.custid 
	From sales.orders o
	inner join sales.OrderDetails od
		on o.orderid = od.orderid
	) c(productid,orderyear,cust)
Group by cust,orderyear
Order By cust,orderyear;

--2
with DistProductCount as 
	(Select
		distinct od.productid,
		year(o.orderdate) as orderyear,
		c.country as country
	From sales.orders o
	inner join sales.OrderDetails od
		on o.orderid = od.orderid
	join sales.Customers c
		on o.custid = c.custid)

select
	country,
	Count(productid) distProduct,
	orderyear
From DistProductCount
Group by country,orderyear
Order By country,orderyear;

--3
DROP VIEW IF EXISTS Sales.CountryAnnual;
GO
CREATE VIEW Sales.CountryAnnual
AS 

select
	country,
	sum(dollaramount) as total,
	orderyear
From (Select
		year(o.orderdate) as orderyear,
		(od.qty * od.unitprice) as DollarAmount, 
		c.country as country
	From sales.orders o
	inner join sales.OrderDetails od
		on o.orderid = od.orderid
	join sales.Customers c
		on o.custid = c.custid) c
Group by country,orderyear;

--4
DROP FUNCTION IF EXISTS dbo.GetCustOrders;
GO
CREATE FUNCTION dbo.GetCustOrders
(@salescountry as nvarchar(25)) RETURNS TABLE
AS
RETURN
select
	country,
	productid,
	productname
From (Select
		distinct od.productid,
		p.productname,
		c.country as country
	From sales.orders o
	inner join sales.OrderDetails od
		on o.orderid = od.orderid
	join sales.Customers c
		on o.custid = c.custid
	join Production.Products p
		on od.productid = p.productid) c
where country like @SalesCountry

--5
--Use the CROSS APPLY operator to create a query showing the top three products shipped to customers
--in each country. Your report should contain the name of the country, the product id, the product name,
--and the number of products shipped to customers in that country.
--Page
select
 country,
 productid,
 productname,
 sum(od.qty)
 from Production.Products
 Cross apply
	(select 
	From sales.OrderDetails
	inner join ) as od