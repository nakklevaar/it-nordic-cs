SELECT
	P.Id AS PpoductId,
	P.[Name],
	P.[Price],
	OI.[NumberOfItems],
	P.[Price] * OI.[NumberOfItems]
FROM dbo.[OrderItem] AS OI
INNER JOIN dbo.[Product] AS P
	ON P.Id = OI.ProductId
WHERE OI.OrderId = 22

SELECT
	SUM(P.[Price] * OI.[NumberOfItems]) AS TotalSum
FROM dbo.[OrderItem] AS OI
INNER JOIN dbo.[Product] AS P
	ON P.Id = OI.ProductId
WHERE OI.OrderId = 22

--*

SELECT
	SUM(P.[Price] * OI.[NumberOfItems]) AS TotalSum
FROM dbo.[OrderItem] AS OI
INNER JOIN dbo.[Product] AS P
	ON P.Id = OI.ProductId
INNER JOIN dbo.[Order] AS O
	ON OI.OrderId = O.Id
INNER JOIN dbo.Customer AS C
	ON C.Id = O.CustomerId
WHERE C.[Name] = 'Мария'

--
SELECT SubTotal.[Name], SUM(SubTotal.Total)
FROM
	(SELECT
		C.[Name],
		(1-ISNULL(O.Discount,0))*SUM(P.[Price] * OI.[NumberOfItems]) AS Total
	FROM dbo.[OrderItem] AS OI
	INNER JOIN dbo.[Order] AS O
		ON OI.OrderId = O.Id
	INNER JOIN dbo.[Product] AS P
		ON P.Id = OI.ProductId
	INNER JOIN dbo.Customer AS C
		ON C.Id = O.CustomerId
	GROUP BY O.Discount,C.[Name]
	) AS SubTotal
GROUP BY SubTotal.[Name]

--Доля денег от общей суммы
DECLARE @total AS MONEY
SELECT @total = SUM(T.[Sum]) 
FROM
	(SELECT
		C.[Name],
		(1-ISNULL(O.Discount,0))*SUM(P.[Price] * OI.[NumberOfItems]) AS [Sum]
	FROM dbo.[OrderItem] AS OI
	INNER JOIN dbo.[Order] AS O
		ON OI.OrderId = O.Id
	INNER JOIN dbo.[Product] AS P
		ON P.Id = OI.ProductId
	INNER JOIN dbo.Customer AS C
		ON C.Id = O.CustomerId
	GROUP BY O.Discount,C.[Name]
	) AS T
GROUP BY T.[Name]

SELECT T.[Name], SUM(T.[Sum]),SUM(T.[Sum])/@total
FROM
	(SELECT
		C.[Name],
		(1-ISNULL(O.Discount,0))*SUM(P.[Price] * OI.[NumberOfItems]) AS [Sum]
	FROM dbo.[OrderItem] AS OI
	INNER JOIN dbo.[Order] AS O
		ON OI.OrderId = O.Id
	INNER JOIN dbo.[Product] AS P
		ON P.Id = OI.ProductId
	INNER JOIN dbo.Customer AS C
		ON C.Id = O.CustomerId
	GROUP BY O.Discount,C.[Name]
	) AS T
GROUP BY T.[Name]