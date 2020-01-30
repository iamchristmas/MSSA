USE TSQLV4;
GO
--EX 1
Select e.empid,e.firstname,e.lastname,n.empid
From HR.Employees as e
CROSS JOIN hr.Employees as n
	Where n.empid <= 5

--EX 2
SELECT E.empid,
DATEADD(day, D.n - 1, CAST('20160612' AS DATE)) AS dt
FROM HR.Employees AS E
CROSS JOIN dbo.Nums AS D
WHERE D.n <= DATEDIFF(day, '20160612', '20160616') + 1
ORDER BY empid, dt;

----EX 3 Return US customers, and for each customer return the total number of orders and total quantities:
Select	c.custid,
		count(distinct o.orderid) as numorders,
		sum(od.qty) as totalyqty
from sales.Customers as c
inner join sales.orders as o
	on c.custid = o.custid
inner join sales.OrderDetails as od
	on o.orderid = od.orderid 
	where shipcountry LIKE 'USA'
group by c.custid

--EX 4
select	o.custid,
		c.companyname,
		o.orderid,
		o.orderdate
from Sales.orders as o
left join sales.Customers as c
	on o.custid = c.custid

--EX 5 Return customers who placed no orders:
Select c.custID,o.Orderid
from sales.customers as c
left join sales.orders o
	on c.custid = o.custid
Where o.orderid IS NULL

--EX 6 Return customers with orders placed on February 12, 2016, along with their orders
Select c.custid,c.companyname,o.orderid,o.orderdate
From sales.customers as c
inner join sales.orders as o
	on c.custid = o.custid
	where o.orderdate = '2016/02/12'

--EX 7 Write a query that returns all customers in the output, but matches them with their respective orders
--only if they were placed on February 12, 2016:
Select c.custid,c.companyname,o.orderid, o.orderdate
From sales.customers as c
left join sales.orders as o
	on c.custid = o.custid
	and o.orderdate = '2016/02/12'

--EX 8 
-- SELECT C.custid, C.companyname, O.orderid, O.orderdate
-- FROM Sales.Customers AS C
-- LEFT OUTER JOIN Sales.Orders AS O
-- ON O.custid = C.custid
-- WHERE O.orderdate = '20160212'
-- OR O.orderid IS NULL;

-- This query is incorrect because of how the where clause is implemented. 
-- If this query runs then it will only return customers who have no orders or orders on feb 12, 2016

--EX 9 
Select c.custid,c.companyname,
	(
		CASE
			WHen o.orderdate = '2016/02/12' then 'Yes'
			WHen o.orderdate IS NULL then 'No'
		END
	) as HasOrderOn20160212
From sales.customers as c
left join sales.orders as o
	on c.custid = o.custid
	and o.orderdate = '2016/02/12'



