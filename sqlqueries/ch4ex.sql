--EXERCISE 1------------------------------------------------------
--Write a query that returns all orders placed on the last day of activity that can be found in the Orders
--table:

select
	orderid,
	orderdate,
	custid,
	empid
From Sales.orders
where orderdate in (
select 
	max(orderdate) 
from sales.orders)
--EXERCISE 2------------------------------------------------------
--Write a query that returns all orders placed by the customer(s) who placed the highest number of or-
--ders. Note that more than one customer might have the same number of orders:
select
	custid,
	orderid,
	orderdate,
	empid
From Sales.orders
Where custid in (
select top (1) WITH TIES custid 
from sales.orders
group by custid
order by COUNT(orderid) DESC)
--EXERCISE 3------------------------------------------------------
--Write a query that returns employees who did not place orders on or after May 1, 2016:
select 
	e.empid,
	e.firstname,
	e.lastname
from hr.employees as e 
inner join (
select empid,max(orderdate)as maxorderdate
from sales.orders
group by empid
) as o on e.empid = o.empid
where o.maxorderdate < '20160501'
order by e.empid
--EXERCISE 4------------------------------------------------------
--Write a query that returns countries where there are customers but not employees:
select 
	distinct c.country
from sales.customers as c
WHERE c.country NOT IN(
select country
from hr.Employees
)
--EXERCISE 5------------------------------------------------------
--Write a query that returns for each customer all orders placed on the customer’s last day of activity:
select 
	o.custid,
	o.orderid,
	o.orderdate,
	o.empid
From sales.orders as o
inner join 
(
select custid,MAX(orderdate)as morderdate
from sales.orders
group by custid
) as m 
on o.custid = m.custid
and o.orderdate = m.morderdate
order by o.custid
--EXERCISE 6------------------------------------------------------
--Write a query that returns customers who placed orders in 2015 but not in 2016:
select 
	c.custid,
	c.companyname
From sales.customers c
where exists(
select *
from sales.orders o
where 
	o.custid = c.custid 
	AND O.orderdate >= '20150101'
	AND O.orderdate < '20160101')
AND Not Exists(
select *
from sales.orders o
where 
	o.custid = c.custid 
	AND O.orderdate >= '20160101'
	AND O.orderdate < '20170101')
--EXERCISE 7------------------------------------------------------
	--Write a query that returns customers who ordered product 12:
Select 
	custid,
	companyname
From sales.customers c
where custid in 
(
	select  distinct o.custid
	from sales.Orders o
	where 
		o.custid = c.custid
		and exists
			(
			select *
			from sales.OrderDetails od
			where
				od.orderid = o.orderid and
				od.productid = '12'
			)
)
