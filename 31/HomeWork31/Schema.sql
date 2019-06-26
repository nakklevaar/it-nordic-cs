--CREATE DATABASE Storage
GO
USE Storage
GO

DROP TABLE IF EXISTS [dbo].[ReminderItems]
GO
CREATE TABLE dbo.ReminderItems (
	Id UNIQUEIDENTIFIER NOT NULL,
	[Date]  DATETIMEOFFSET NOT NULL,
	ContactId VARCHAR(30) NOT NULL,
	[Message] VARCHAR(100) NOT NULL,
	StatusId TINYINT NOT NULL
	CONSTRAINT PK_ReminderItems PRIMARY KEY CLUSTERED (Id ASC)
);
GO

ALTER TABLE [dbo].[ReminderItems] DROP CONSTRAINT IF EXISTS [FK_ReminderItems_StatusId]
GO

DROP TABLE IF EXISTS [dbo].[Statuses]
GO
CREATE TABLE dbo.Statuses (
	Id TINYINT NOT NULL,
	[Status] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Statuses PRIMARY KEY CLUSTERED (Id ASC),
	CONSTRAINT UQ_Statuses UNIQUE ([Status])
);
GO

ALTER TABLE dbo.ReminderItems ADD CONSTRAINT
	FK_ReminderItems_StatusId FOREIGN KEY(StatusId)
		REFERENCES dbo.Statuses (Id)


GO

INSERT INTO dbo.Statuses (Id, [Status]) VALUES (0,'Awaiting'),(1, 'Ready'),(2,'Sent'),(3,'Failed')
