USE TSQLV4;
GO
--Return US customers, and for each customer return the total number of orders and total quantities:
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


select * from sales.orders
--select * from Sales.OrderDetails as o