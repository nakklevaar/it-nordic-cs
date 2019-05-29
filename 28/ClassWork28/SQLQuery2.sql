USE LiveHeroTour;
GO
--DROP TABLE dbo.Goods
CREATE TABLE dbo.Goods (
	Id INT NOT NULL IDENTITY(1,1),
	CategoryId UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Goods PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Goods_Name UNIQUE ([Name])
);
ALTER TABLE dbo.Goods
	ADD CONSTRAINT FK_Goods_CategoryId FOREIGN KEY (CategoryId)
		REFERENCES dbo.Category(Id)

DECLARE @guid AS UNIQUEIDENTIFIER
SELECT @guid = Id
FROM dbo.Category
WHERE [Name] = 'Mobile Phone'

--PRINT @guid

--DELETE FROM dbo.Goods
TRUNCATE TABLE dbo.Goods

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (@guid,'Iphone X')
PRINT 'ID of IphoneX is ' + CONVERT(VARCHAR(15), SCOPE_IDENTITY())

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (@guid,'Xiaomi Mi9')
PRINT 'ID of Xiaomi Mi9 ' + CAST(SCOPE_IDENTITY() AS VARCHAR(15))

SELECT * FROM dbo.Goods
