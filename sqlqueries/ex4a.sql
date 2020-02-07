--EXERCISE 1------------------------------------------------------
--The following query attempts to filter orders that were not placed on the last day of the year. It’s supposed to return the order ID, order date, customer ID, employee ID, and respective end-of-year date for each order:
	--SELECT orderid, orderdate, custid, empid,
	--DATEFROMPARTS(YEAR(orderdate), 12, 31) AS endofyear
	--FROM Sales.Orders
	--WHERE orderdate <> endofyear;
--When you try to run this query, you get the following error:
--Msg 207, Level 16, State 1, Line 233
--Invalid column name ‘endofyear'.
--Explain what the problem is, and suggest a valid solution.

--Since endofyear is used in the where statement, the statement cannot be filtered properly. You would need a subquery like the following:
SELECT orderid, orderdate, custid, empid,YEAR(orderdate)
FROM Sales.Orders
WHERE orderdate NOT IN (
select DATEFROMPARTS(YEAR(orderdate), 12, 31)
FROM Sales.Orders
)

--EXERCISE 2------------------------------------------------------
--Write a query that returns the maximum value in the orderdate column for each employee
select 
	o.empid,
	o.orderdate,
	o.orderid,
	o.custid
from sales.orders as o
inner join (
	select empid,max(orderdate) as maxorderdate
	from sales.orders
	group by empid
	) as m
on o.empid = m.empid
AND o.orderdate = m.maxorderdate
