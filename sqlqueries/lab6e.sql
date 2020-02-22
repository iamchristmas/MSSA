--Christopher Smith LAB6E





-- Exercise 1
-- In this exercise, you create a system-versioned temporal table and identify it in SSMS.
-- Exercise 1-1
-- Create a system-versioned temporal table called Departments with an associated history table called
-- DepartmentsHistory in the database TSQLV4. The table should have the following columns: deptid INT,
-- deptname VARCHAR(25), and mgrid INT, all disallowing NULLs. Also include columns called validfrom
-- and validto that define the validity period of the row. Define those with precision zero (1 second), and
-- make them hidden.
-- Exercise 1-2
-- Browse the object tree in Object Explorer in SSMS, and identify the Departments table and its
-- associated history table.
Create table dbo.Departments
(
    depid   INT not NULL    
        constraint PK_Departments PRIMARY KEY NONCLUSTERED,
    depname nvarchar(25)    not null,
    mgrid  int not null,
    systart DATETIME2(0) 
        generated always as row START hidden not null,
    sysend DATETIME2(0)
        generated always as row end hidden not null,
    PERIOD FOR SYSTEM_TIME (systart, sysend),
    index ix_Departments clustered(depid,systart,sysend)
)
WITH (SYSTEM_VERSIONING = ON (History_table =dbo.DepartmentsHistory))

-- Exercise 2
-- In this exercise, you’ll modify data in the table Departments. Note the point in time in UTC when you
-- submit each statement, and mark those as P1, P2, and so on. You can do so by invoking the SYSUTCDATETIME
-- function in the same batch in which you submit the modification. Another option is to
-- query the Departments table and its associated history table and to obtain the point in time from the
-- validfrom and validto columns.
-- Exercise 2-1
-- Insert four rows to the table Departments with the following details, and note the time when you apply
-- this insert (call it P1):
-- deptid: 1, deptname: HR, mgrid: 7
--  deptid: 2, deptname: IT, mgrid: 5
-- --  deptid: 3, deptname: Sales, mgrid: 11
-- --  deptid: 4, deptname: Marketing, mgrid: 13
INSERT into dbo.Departments(depid,depname)
values
(1,'HR'),
(2,'IT'),
(3,'SALES'),
(4,'MARKETING');
SELECT SYSDATETIME() as createdtime;
-- created time 2020-02-20 06:33:05.2211007 (SYS TIME)

-- Exercise 2-2
-- In one transaction, update the name of department 3 to Sales and Marketing and delete department 4.
-- Call the point in time when the transaction starts P2.
select SYSDATETIME() as p2;

Update dbo.Departments
    set depname = 'Sales and Marketing'
where depid = 3;

delete from dbo.Departments
WHERE depid = 4;
--p2 = 2020-02-20 06:37:33.3887888
-- Exercise 2-3
-- Update the manager ID of department 3 to 13. Call the point in time when you apply this update P2.
select SYSDATETIME() as p3;
update dbo.Departments
    set mgrid = 13
where depid = 3;
--p2 = 2020-02-20 06:47:42.1200694

-- Exercise 3
-- In this exercise, you’ll query data from the table Departments.

-- Exercise 3-1
-- Query the current state of the table Departments:

--  Desired output:
-- deptid deptname mgrid
-- ----------- ------------------------- -----------
-- 1 HR 7
-- 2 IT 5
-- 3 Sales and Marketing 13
Select * from dbo.Departments

-- Exercise 3-2
-- Query the state of the table Departments at a point in time after P2 and before P3:
--  Desired output:
-- deptid deptname mgrid
-- ----------- ------------------------- -----------
-- 1 HR 7
-- 2 IT 5
-- 3 Sales and Marketing 11
Select * from dbo.Departments
for SYSTEM_TIME as of '2020-02-20 06:37:33.3887888'

-- Exercise 3-3
-- Query the state of the table Departments in the period between P2 and P3. Be explicit about the
-- column names in the SELECT list, and include the validfrom and validto columns:
--  Desired output (with validfrom and validto reflecting your modification times):
-- deptid deptname mgrid validfrom validto
-- ------- -------------------- ------ -------------------- --------------------
-- 1 HR 7 2016-02-18 10:26:07 9999-12-31 23:59:59
-- 2 IT 5 2016-02-18 10:26:07 9999-12-31 23:59:59
-- 3 Sales and Marketing 13 2016-02-18 10:30:40 9999-12-31 23:59:59
-- 3 Sales and Marketing 11 2016-02-18 10:28:27 2016-02-18 10:30:40

Select depid,depname,mgrid,systart,sysend from dbo.Departments
for SYSTEM_TIME between '2020-02-20 06:37:33.3887888' and ' 2020-02-20 06:47:42.1200694'

-- Exercise 4
-- Drop the table Departments and its associated history table.
IF OBJECT_ID(N'dbo.Departments', N'U') IS NOT NULL
BEGIN
IF OBJECTPROPERTY(OBJECT_ID(N'dbo.Departments', N'U'), N'TableTemporalType') = 2
ALTER TABLE dbo.Departments SET ( SYSTEM_VERSIONING = OFF );
DROP TABLE IF EXISTS dbo.DepartmentsHistory, dbo.Departments;
END;
GO
