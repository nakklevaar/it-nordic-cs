USE LiveHeroTour;
GO
CREATE PROCEDURE dbo.CreateGoodsItem (
	@categoryName AS VARCHAR(50),
	@goodsItemName AS VARCHAR(100),
	@goodsItemId AS INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @guid AS UNIQUEIDENTIFIER
	SET @guid = dbo.GetCategoryId(@categoryName)

	SET XACT_ABORT ON
	BEGIN TRANSACTION

	BEGIN TRY

		IF(@guid IS NULL)
		EXEC dbo.CreateCategory
			@categoryName = @categoryName,
			@guid = @guid OUTPUT

		INSERT INTO dbo.Goods (CategoryId, [Name])
			VALUES(@guid,@goodsItemName)
		SET @goodsItemId = SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
		IF (XACT_STATE() = -1)
			ROLLBACK TRANSACTION
		THROW
	END CATCH

	IF (XACT_STATE()= -1)
		COMMIT TRANSACTION
END
GO

SELECT * FROM dbo.Goods
SELECT * FROM dbo.Category
EXECUTE dbo.CreateGoodsItem 'TV', 'Panasonic 200', 0
EXECUTE dbo.CreateGoodsItem 'Printer', 'Epson 300', 0
EXECUTE dbo.CreateGoodsItem 'Radio', 'Epson 300', 0

