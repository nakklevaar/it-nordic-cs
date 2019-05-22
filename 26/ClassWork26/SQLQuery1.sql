CREATE DATABASE PostalSending;
GO
USE PostalSending;
GO
CREATE TABLE [dbo].[PostSending](
	[SenderName] [varchar](20),
	[ReceiverName] [varchar](50),
	[DocumentTitle] [tinyint],
	[NumberOfPages] [tinyint],
	[SendingDate] [datetime],
	[ExpectedReceivingDate] [date]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[PostSending]
           ([SenderName]
           ,[ReceiverName]
           ,[DocumentTitle]
           ,[NumberOfPages]
           ,[SendingDate]
		   ,[ExpectedReceivingDate])
     VALUES
           ('Alex','Serg','doctitle','23','2019-05-07 13:43','2019-06-17')
GO

INSERT INTO [dbo].[PostSending]
           ([SenderName]
           ,[ReceiverName]
           ,[DocumentTitle]
           ,[NumberOfPages]
           ,[SendingDate]
		   ,[ExpectedReceivingDate])
     VALUES
           ('sam','vanya','Book','113','2023-15-09 13:43','2029-11-08')
GO
DROP TABLE [dbo].[PostSending]
DROP DATABASE PostalSending