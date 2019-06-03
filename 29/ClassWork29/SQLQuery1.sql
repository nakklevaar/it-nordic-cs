USE LiveHeroTour2
GO

SELECT [Name], LEN([Name])
FROM Product AS P

DECLARE @year AS INT
SET @year = YEAR(GETUTCDATE())
SELECT @year;

SELECT MIN(OrderDate), MAX(OrderDate)
FROM [Order]

--2
SELECT COUNT(DISTINCT OrderId)
FROM [OrderItem]

--3
SELECT MAX(Id)
FROM [Order]

--4
SELECT AVG(Discount)
FROM [Order]

--6

SELECT MAX(OrderDate)
FROM [Order]
WHERE YEAR(OrderDate)=2018

--7
SELECT MAX(LEN([Name]))
FROM [Product]