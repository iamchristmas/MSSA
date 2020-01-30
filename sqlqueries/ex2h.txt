USE Northwind; 
GO
--Part 1
SELECT	ContactTitle + ' ' +  ContactName + CHAR(13) +
		CompanyName + CHAR(13) +
		Address + CHAR(13) +
		City + ', ' + ISNULL(Region,'') + ' ' + ISNULL(PostalCode,'') + ' ' + Country+
		Char(13) +
		Char(13) AS ShippingLabel
From Customers
GO;

--Part 2
Select	parsename(replace(ContactName, ' ', '.'), 1) + ', ' +
		parsename(replace(ContactName, ' ', '.'), 2) + ' ' + 
		ISNULL((parsename(replace(ContactName, ' ', '.'), 3)),'') + ' ' +
		CompanyName + ' ' +
		Phone
		AS Contact
From Customers;

GO
--Part 3
Select	OrderID,
		OrderDate,
		ShippedDate, 
		DATEDIFF(DAY,OrderDate,ShippedDate)		
From Orders;
GO

--Part 4
declare @bday date;
set @bday = Datetimefromparts(1994,9,26,0,0,0,0) 
Select  dayssince = datediff(DAY,@bday,GETDATE()),
		datediff(MONTH,@bday,GETDATE()) as monthssince,
		Floor(datediff(month,@bday,GETDATE())/12) as yearssince,
		getdate() as today;
GO