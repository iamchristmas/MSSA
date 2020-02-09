--Christopher Smith
--EX4C
USE TSQLV4;
GO
--Exercise 2
--Write a query that generates a virtual auxiliary table of 10 numbers in the range 1 through 10 without
--using a looping construct. You do not need to guarantee any order of the rows in the output of your
--solution:
-- Tables involved: None
-- Desired output:
--n
-------------
--1
--2
--3
--4
--5
--6
--7
--8
--9
--10
--(10 row(s) affected)

Select 1 n
Union ALL Select 2
Union ALL Select 3
Union ALL Select 4
Union ALL Select 5
Union ALL Select 6
Union ALL Select 7
Union ALL Select 8
Union ALL Select 9
Union ALL Select 10;
GO
--Exercise 3
--Write a query that returns customer and employee pairs that had order activity in January 2016 but not
--in February 2016:
-- Table involved: Sales.Orders table
-- Desired output:
--custid empid
------------- -----------
--1 1
--3 3
--5 8
--5 9
--6 9
--7 6
--9 1
--12 2
--16 7
--17 1
--20 7
--24 8
--25 1
--26 3
--32 4
--38 9
--39 3
--40 2
Select custid, empid
From Sales.Orders
Where orderdate >= '20160101' AND orderdate < '20160201'
Except
Select custid, empid
From Sales.Orders
Where orderdate >= '20160201' AND orderdate < '20160301';