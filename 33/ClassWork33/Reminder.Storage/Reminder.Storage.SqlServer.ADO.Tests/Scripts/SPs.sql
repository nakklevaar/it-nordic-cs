DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
GO
CREATE PROCEDURE [dbo].[AddReminderItem] (
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT,
	@reminderId AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE
		@now AS DATETIMEOFFSET,
		@tempReminderId AS UNIQUEIDENTIFIER
	
	SELECT 
		@now = SYSDATETIMEOFFSET(),
		@tempReminderId = NEWID(); 

	INSERT INTO [dbo].[ReminderItem](
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId],
		[CreatedDate],
		[UpdatedDate])
	VALUES (
		@tempReminderId,
		@contactId,
		@targetDate,
		@message,
		@statusId,
		@now,
		@now)
	
	SET @reminderId = @tempReminderId
END
GO

DROP PROCEDURE IF EXISTS dbo.GetReminderItemById
GO
CREATE PROCEDURE dbo.GetReminderItemById (
	@reminderId AS UNIQUEIDENTIFIER)

AS BEGIN
	SELECT
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM dbo.ReminderItem
	WHERE Id = @reminderId
END
GO

DROP PROCEDURE IF EXISTS UpdateOneStatus
GO
CREATE PROCEDURE dbo.UpdateOneStatus (
	@id UNIQUEIDENTIFIER,
	@statusId TINYINT
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.ReminderItem
	SET StatusId = @statusId
	WHERE Id = @id

END
GO

DROP PROCEDURE IF EXISTS dbo.GetReminderItemsCount
GO
CREATE PROCEDURE dbo.GetReminderItemsCount
AS BEGIN
	SELECT COUNT(*)
	FROM dbo.ReminderItem
END
GO

DROP PROCEDURE IF EXISTS dbo.RemoveReminderItemById
GO
CREATE PROCEDURE dbo.RemoveReminderItemById (
	@reminderId AS UNIQUEIDENTIFIER)

AS BEGIN
	DELETE FROM dbo.ReminderItem
	WHERE Id = @reminderId
		
	SELECT CAST(@@ROWCOUNT AS BIT)
END
GO

CREATE TABLE #ReminderItem (
	Id UNIQUEIDENTIFIER NOT NULL
)
GO

DROP PROCEDURE IF EXISTS dbo.UpdateReminderItemsBulk
GO
CREATE PROCEDURE dbo.UpdateReminderItemsBulk (
	@statusId AS TINYINT
)
AS BEGIN
	UPDATE R
		SET R.StatusId = @statusId,
		R.UpdateDate = SYSDATETIMEOFFSET()
	FROM dbo.ReminderItem AS R
	INNER JOIN #ReminderItem AS T
	ON T.Id = R.Id
END
GO