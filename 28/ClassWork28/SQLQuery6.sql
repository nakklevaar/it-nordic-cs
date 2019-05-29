USE LiveHeroTour;
GO

SELECT * FROM dbo.Category
SELECT * FROM dbo.Goods

SELECT *
FROM dbo.Category
FULL OUTER JOIN dbo.Goods
	ON dbo.Goods.CategoryId = dbo.Category.Id

SELECT *
FROM dbo.Category
INNER JOIN dbo.Goods
	ON dbo.Goods.CategoryId = dbo.Category.Id

SELECT *
FROM dbo.Category AS C
LEFT JOIN dbo.Goods AS G
	ON G.CategoryId = C.Id
WHERE G.CategoryId IS NULL