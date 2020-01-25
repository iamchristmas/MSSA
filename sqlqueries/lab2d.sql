USE Northwind;
GO
--Question 1.
Select CompanyName
From customers
WHERE	country like N'USA' or 
		country like N'Mexico' or
		country like N'Canada';
GO
--Question 2.
Select OrderID,OrderDate
From Orders
Where	orderdate >= DATEFROMPARTS(1998,4,1) AND 
		orderdate < DATEFROMPARTS(1998,5,1);
GO
--Question 3.
Select ProductName 
From Products
Where ProductName like N'%sauce%';
GO
--Question 4.
Select *
From Products
Where ProductName like N'%dried%';
GO
--Question 5
select EmployeeID,ShipCountry,OrderDate
From Orders
WHERE MONTH(Orderdate) = 12 AND ShipCountry = N'Germany'
Group By EmployeeID,ShipCountry,OrderDate;
Go
--Question 6
select	COUNT(OrderID) AS totalorders,
		COUNT(case when Discount > 0 then 1 else null end) As discountorders
From [Order Details]
Where productID = 19;
GO
--Question 7
Select	TitleOfCourtesy + ' ' + 
		Firstname + ' '+
		Lastname + ' '+ CHAR(13) +
		Title + CHAR(13) +  
		'-------------------------'
FROM Employees;
GO
--Question 8.
Select customers.ContactName as customer,Employees.FirstName as employee
From Orders
INNER JOIN Employees
ON orders.EmployeeID = Employees.EmployeeID
Inner join customers
on orders.customerId = customers.customerid
group by ContactName,FirstName;
--go
--Question 9.
select parsename(replace(ContactName,' ', '.'),1) as lastname 
from customers
order by lastname;
--Question 10.
Select DATEDIFF(DAY,DATEFROMPARTS(1994,9,26),GETDATE()) AS daysold
