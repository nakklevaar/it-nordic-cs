--DROP PROCEDURE dbo.AddReminder
CREATE PROCEDURE dbo.AddReminder (
	@id UNIQUEIDENTIFIER OUTPUT,
	@date DATETIMEOFFSET,
	@contactId VARCHAR(30),
	@message VARCHAR(100),
	@statusId TINYINT
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @guid AS UNIQUEIDENTIFIER = NEWID()
		
	INSERT INTO dbo.ReminderItems (
	Id,
	[Date],
	ContactId,
	[Message],
	StatusId
	)
	VALUES (
	@guid,
	@date,
	@contactId,
	@message,
	@statusId
	)

	SELECT @id = @guid

END
GO 

--DROP PROCEDURE dbo.UpdateOneStatus
CREATE PROCEDURE dbo.UpdateOneStatus (
	@id UNIQUEIDENTIFIER,
	@statusId TINYINT
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.ReminderItems
	SET StatusId = @statusId
	WHERE Id = @id

END
GO