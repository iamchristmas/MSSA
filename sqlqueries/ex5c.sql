
--Create Starter table
USE TSQLV4;
DROP TABLE IF EXISTS dbo.Orders;
CREATE TABLE dbo.Orders
(
orderid INT NOT NULL,
orderdate DATE NOT NULL,
empid INT NOT NULL,
custid VARCHAR(5) NOT NULL,
qty INT NOT NULL,
CONSTRAINT PK_Orders PRIMARY KEY(orderid)
);
INSERT INTO dbo.Orders(orderid, orderdate, empid, custid, qty)
VALUES
(30001, '20140802', 3, 'A', 10),
(10001, '20141224', 2, 'A', 12),
(10005, '20141224', 1, 'B', 20),
(40001, '20150109', 2, 'A', 40),
(10006, '20150118', 1, 'C', 14),
(20001, '20150212', 2, 'B', 12),
(40005, '20160212', 3, 'A', 10),
(20002, '20160216', 1, 'C', 20),
(30003, '20160418', 2, 'B', 15),
(30004, '20140418', 3, 'C', 22),
(30007, '20160907', 3, 'D', 30);
SELECT * FROM dbo.Orders;

--EX1
-- Write a query against the dbo.Orders table that computes both a rank and a dense rank for each
-- customer order, partitioned by custid and ordered by qty:

SELECT
    custid, orderid, qty ,
    RANK() OVER(PARTITION BY custid ORDER BY qty) as rnk, -- ranks based upon quantity per window, in this case its order.
    DENSE_RANK() OVER(PARTITION BY custid ORDER BY qty) as drnk --ignores the placeholdre value of a duplicate value and counts the rank overall.
FROM dbo.Orders;

--EX2
-- Earlier in the chapter in the section “Ranking window functions,” I provided the following query against
-- the Sales.OrderValues view to return distinct values and their associated row numbers:
-- SELECT val, ROW_NUMBER() OVER(ORDER BY val) AS rownum
-- FROM Sales.OrderValues
-- GROUP BY val;
-- Can you think of an alternative way to achieve the same task?

SELECT val, DENSE_RANK() OVER(ORDER BY val ) AS rownum -- Alternative solution provides an output that matches the desired outcome
FROM Sales.OrderValues
GROUP BY val;

--EX3
-- Write a query against the dbo.Orders table that computes for each customer order both the difference
-- between the current order quantity and the customer’s previous order quantity and the difference between 
-- the current order quantity and the customer’s next order quantity:

Select 
    custid, orderid, qty,
    --sets the window as custid then orders by date then id
    --lag selects previous value
    qty - lag(qty) over(partition by custid
            order by orderdate,orderid) as diffprev,
    --sets the window as custid then orders by date then id
    --lead selects next value
    qty - lead(qty) over(partition by custid
            order by orderdate,orderid) as diffnext
FROM dbo.Orders;

--EX4
-- Write a query against the dbo.Orders table that returns a row for each employee, a column for each
-- order year, and the count of orders for each employee and order year:

WITH orderbyyear as(
    select empid, year(orderdate) as orderyear
    from dbo.orders
)

Select empid,
    COUNT(case when orderyear = 2014 then orderyear end) as cnt2014,
    COUNT(case when orderyear = 2015 then orderyear end) as cnt2015,
    COUNT(case when orderyear = 2016 then orderyear end) as cnt2016
FROM orderbyyear
group by empid

--EX5
--Run the following code to create and populate the EmpYearOrders table:
USE TSQLV4;
DROP TABLE IF EXISTS dbo.EmpYearOrders;
CREATE TABLE dbo.EmpYearOrders
(
empid INT NOT NULL
CONSTRAINT PK_EmpYearOrders PRIMARY KEY,
cnt2014 INT NULL,
cnt2015 INT NULL,
cnt2016 INT NULL
);
INSERT INTO dbo.EmpYearOrders(empid, cnt2014, cnt2015, cnt2016)
SELECT empid, [2014] AS cnt2014, [2015] AS cnt2015, [2016] AS cnt2016
FROM (SELECT empid, YEAR(orderdate) AS orderyear
FROM dbo.Orders) AS D
PIVOT(COUNT(orderyear)
FOR orderyear IN([2014], [2015], [2016])) AS P;

-- Write a query against the EmpYearOrders table that unpivots the data, returning a row for each
-- employee and order year with the number of orders. Exclude rows in which the number of orders is 0
-- (in this example, employee 3 in the year 2015).

SELECT empid,RIGHT(orderyear,4) as orderyear,numorders
FROM dbo.EmpYearOrders
UNPIVOT(numorders for orderyear in(cnt2014 , cnt2015, cnt2016)) as u
where numorders != 0;


--EX6
-- Write a query against the dbo.Orders table that returns the total quantities for each of the following:
-- (employee, customer, and order year), (employee and order year), and (customer and order year).
-- Include a result column in the output that uniquely identifies the grouping set with which the current
-- row is associated:


select 
--define which group each entry belongs to.
    Grouping_ID(
            empid, 
            custid, 
            Year(Orderdate)) AS groupingset,
    empid, 
    custid,
    YEAR(Orderdate) AS orderyear, 
    SUM(qty) AS sumqty
from dbo.Orders
Group by grouping sets( --defines 3 distinct grouping sets
    (empid, custid, YEAR(orderdate)),
    (empid, YEAR(orderdate)),
    (custid, YEAR(orderdate))
);