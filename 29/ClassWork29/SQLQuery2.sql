SELECT C.Id, C.[Name]
FROM dbo.Customer AS C
WHERE C.Id IN (
	SELECT O.CustomerId
	FROM dbo.[Order] as O
	WHERE YEAR(O.OrderDate)=2015
)

--1
SELECT Id
FROM [Order]
WHERE Discount = (
	SELECT MAX(Discount)
	FROM [Order]
	WHERE YEAR(OrderDate)=2016
)

--2
SELECT Id
FROM [Order]
WHERE OrderDate = (
	SELECT MIN(OrderDate)
	FROM [Order]
	WHERE YEAR(OrderDate)=2019
)

--3
SELECT Id, [Name]
FROM Customer
WHERE Id IN (
	SELECT CustomerId
	FROM [Order]
	WHERE Discount = (
		SELECT MAX(Discount)
		FROM [Order]
		WHERE YEAR(OrderDate)=2016
	)
)

--4
SELECT Id, [Name]
FROM Customer
WHERE Id IN (
	SELECT CustomerId
	FROM [Order]
	WHERE OrderDate = (
		SELECT MIN(OrderDate)
		FROM [Order]
		WHERE YEAR(OrderDate)=2019
	)
)

--*
SELECT Id, [Name]
FROM Customer
WHERE Id IN (
	SELECT CustomerId
	From [Order]
	WHERE Discount is NULL)