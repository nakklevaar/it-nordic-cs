CREATE DATABASE Correspondence;
USE Correspondence;

--DROP TABLE dbo.PostalItem
CREATE TABLE dbo.PostalItem(
	Id INT NOT NULL,
	[Name] VARCHAR(250) NOT NULL,
	NumberOfPages INT NOT NULL);
GO

ALTER TABLE dbo.PostalItem
ADD CONSTRAINT PK_PostalItem
	PRIMARY KEY CLUSTERED (Id);

--DROP TABLE dbo.Contractor
CREATE TABLE dbo.Contractor(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	PositionId INT NOT NULL);

ALTER TABLE dbo.Contractor
ADD CONSTRAINT PK_Contractor
	PRIMARY KEY CLUSTERED (Id);

	--DROP TABLE dbo.Position
CREATE TABLE dbo.Position(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	CONSTRAINT PK_Position PRIMARY KEY CLUSTERED (Id));

--DROP TABLE dbo.Adress
CREATE TABLE dbo.[Adress] (
	Id INT NOT NULL,
	CityId INT NOT NULL,
	[Adress] VARCHAR(200) NOT NULL,
	CONSTRAINT PK_Adress PRIMARY KEY CLUSTERED (Id));

CREATE TABLE dbo.City (
	Id INT NOT NULL,
	[Name] VARCHAR(200) NOT NULL,
	CONSTRAINT PK_City PRIMARY KEY CLUSTERED (Id));

CREATE TABLE dbo.[Status] (
	Id INT NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED (Id));

CREATE TABLE dbo.SendingStatus (
	PostalItemId INT NOT NULL,
	StatusId INT NOT NULL,
	UpdateStatusTime DATETIMEOFFSET NOT NULL,
	SenderId INT NOT NULL,
	SenderAdress INT NOT NULL,
	ReceiverId INT NOT NULL,
	ReceiverAdress INT NOT NULL,
	CONSTRAINT PK_SendingStatus PRIMARY KEY CLUSTERED(
		PostalItemId,
		StatusId,
		UpdateStatusTime,
		SenderId,
		SenderAdress,
		ReceiverId,
		ReceiverAdress));
GO
--create foreign keys
ALTER TABLE dbo.[Adress]
ADD CONSTRAINT FK_Adress_CityId FOREIGN KEY (CityId)
	REFERENCES dbo.City(Id)
