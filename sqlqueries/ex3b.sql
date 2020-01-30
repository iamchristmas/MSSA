USE TSQLV4;
GO
--EX 1
Select e.empid,e.firstname,e.lastname,n.empid
From HR.Employees as e
CROSS JOIN hr.Employees as n
	Where n.empid <= 5

--EX 2
Select e.empid,d.date
FROM HR.Employees as e
CROSS JOIN (SELECT YEAR(2016) as theyear
			where theyear between '2016/06/22' and '2016/06/16') AS d

----EX 3 Return US customers, and for each customer return the total number of orders and total quantities:
--Select	c.custid,
--		count(distinct o.orderid) as numorders,
--		sum(od.qty) as totalyqty
--from sales.Customers as c
--inner join sales.orders as o
--	on c.custid = o.custid
--inner join sales.OrderDetails as od
--	on o.orderid = od.orderid 
--	where shipcountry LIKE 'USA'
--group by c.custid

----EX 4
--select	o.custid,
--		c.companyname,
--		o.orderid,
--		o.orderdate
--from Sales.orders as o
--left join sales.Customers as c
--	on o.custid = c.custid


