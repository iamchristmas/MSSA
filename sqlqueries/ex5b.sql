USE TSQLv4;
GO
-- --EX 1
-- Explain the difference between the UNION All and UNION operators. In what cases are the two
-- equivalent? When they are equivalent, which one should you use?

-- The primary distinction between UNION and UNION All is in the values returned by the query. The UNION
-- operator includes an implied DISTINCT operator, whereas the UNION All will return All results from a 
-- query. UNION All would be the most compute efficient when it is known that the two tables are equal.

--EX 2
-- Write a query that generates a virtual auxiliary table of 10 numbers in the range 1 through 10 without
-- using a looping construct. You do not need to guarantee any order of the rows in the output of your
-- solution:

Select 1 n
    Union All Select 2
    Union All Select 3
    Union All Select 4
    Union All Select 5
    Union All Select 6
    Union All Select 7
    Union All Select 8
    Union All Select 9
    Union All Select 10;
GO


--EX 3
-- Write a query that returns customer and employee pairs that had order activity in January 2016 but not
-- in February 2016:

Select custid, empid
From Sales.Orders
Where orderdate >= '20160101' AND orderdate < '20160201'
Except
Select custid, empid
From Sales.Orders
Where orderdate >= '20160201' AND orderdate < '20160301';
GO

--EX 4
-- Write a query that returns customer and employee pairs that had order activity in both January 2016
-- and February 2016:

Select custid, empid
From Sales.Orders
Where orderdate >= '20160101' AND orderdate < '20160201'
INTERSECT -- includes only matches
Select custid, empid
From Sales.Orders
Where orderdate >= '20160201' AND orderdate < '20160301';

--EX 5
-- Write a query that returns customer and employee pairs that had order activity in both January 2016
-- and February 2016 but not in 2015:

Select custid, empid -- table of pairs in jan
From Sales.Orders
Where orderdate >= '20160101' AND orderdate < '20160201'
INTERSECT -- includes only matches
Select custid, empid -- table of pairs in feb
From Sales.Orders
Where orderdate >= '20160201' AND orderdate < '20160301'
Except
Select custid, empid -- Table of pairs not in 2015
From Sales.Orders
Where orderdate >= '20150101' AND orderdate < '20160101' -- year() doesn't work for some reason when added to except;

GO

--EX 6
-- You are given the following query:
-- -- SELECT country, region, city
-- -- FROM HR.Employees
-- -- UNION All
-- -- SELECT country, region, city
-- -- FROM Production.Suppliers;
-- You are asked to add logic to the query so that it guarantees that the rows from Employees are
-- returned in the output before the row