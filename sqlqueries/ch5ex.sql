--EXERCISE 1------------------------------------------------------
--The following query attempts to filter orders that were not placed on the last day of the year. It�s supposed to return the order ID, order date, customer ID, employee ID, and respective end-of-year date for each order:
	--SELECT orderid, orderdate, custid, empid,
	--DATEFROMPARTS(YEAR(orderdate), 12, 31) AS endofyear
	--FROM Sales.Orders
	--WHERE orderdate <> endofyear;
--When you try to run this query, you get the following error:
--Msg 207, Level 16, State 1, Line 233
--Invalid column name �endofyear'.
--Explain what the problem is, and suggest a valid solution.

--Since endofyear is used in the where statement, the statement cannot be filtered properly. You would need a subquery like the following:
SELECT orderid, orderdate, custid, empid,YEAR(orderdate)
FROM Sales.Orders
WHERE orderdate NOT IN (
select DATEFROMPARTS(YEAR(orderdate), 12, 31)
FROM Sales.Orders
)

--EXERCISE 2-1------------------------------------------------------
--Write a query that returns the maximum value in the orderdate column for each employee

select empid,max(orderdate) as maxorderdate
	from sales.orders
	group by empid
--EXERCISE 2-2------------------------------------------------------
--Encapsulate the query from Exercise 2-1 in a derived table. Write a join query between the derived
--table and the Orders table to return the orders with the maximum order date for each employee:
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

--EXERCISE 3------------------------------------------------------
--Write a query that calculates a row number for each order based on orderdate, orderid ordering:
--THhen Write a query that returns rows with row numbers 11 through 20 based on the row-number definition in
--Exercise 3-1. Use a CTE to encapsulate the code from Exercise 3-1:

with OrdersRows as (Select
	orderid,
	orderdate,
	custid,
	empid,
	ROW_NUMBER() OVER(ORDER BY orderdate,orderid) as rownum
from sales.orders)
Select *
From OrdersRows
WHERE rownum between 11 and 20


--EXERCISE 4------------------------------------------------------

--EXERCISE 5------------------------------------------------------

--EXERCISE 6-1 ----------------------------------------------------
--Create an inline TVF that accepts as inputs a supplier ID (@supid AS INT) and a requested number of
--products (@n AS INT). The function should return @n products with the highest unit prices that are
--supplied by the specified supplier ID:
DROP FUNCTION IF EXISTS Production.TopProducts;
GO
CREATE FUNCTION Production.TopProducts
(@supid AS INT,@N as INT) RETURNS TABLE
AS
RETURN;

SELECT TOP (@n) supplierID,unitprice
FROM Production.Products
WHERE supplierid = @supid
order by unitprice desc;

SELECT * FROM Production.TopProducts(5,2);
