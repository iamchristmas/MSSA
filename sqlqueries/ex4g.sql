--Exercise 4G
--Christopher Smith

--1
select cust,
	Count(productid) distProduct,
	orderyear
from(
Select
	distinct od.productid,
	year(o.orderdate) as orderyear,
	o.custid as cust
From sales.orders o
inner join sales.OrderDetails od
	on o.orderid = od.orderid
) c
Group by cust,orderyear
Order By cust,orderyear
