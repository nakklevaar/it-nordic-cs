USE LiveHeroTour;
GO
CREATE PROCEDURE dbo.CreateCategory (
	@CategoryName AS VARCHAR(50),
	@guid AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @tempGuid AS UNIQUEIDENTIFIER
	SELECT @tempGuid = NEWID()

	INSERT INTO dbo.Category (Id, [Name])
	VALUES(@tempGuid, @CategoryName)

	SET @guid = @tempGuid
END
GO
DELETE FROM dbo.Category WHERE [Name] = 'Test'
DECLARE @guid AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory @CategoryName = 'Test', @guid = @guid OUTPUT
PRINT CONVERT(VARCHAR(50),@guid)


SELECT * FROM dbo.Category