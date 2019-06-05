--CREATE DATABASE [OnlineStore]
GO
USE [OnlineStore]
GO
-- drop foreign keys
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT IF EXISTS [FK_Order_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT IF EXISTS [FK_OrderItem_OrderId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT IF EXISTS [FK_OrderItem_ProductId]
GO
-- re-create tables
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
	DROP TABLE [dbo].[Product]
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(300) NOT NULL,
	[Price] SMALLMONEY NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED (Id ASC),
);
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
	DROP TABLE [dbo].[Customer]
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED (Id ASC)
);
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
	DROP TABLE [dbo].[Order]
GO
CREATE TABLE [dbo].[Order](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[CustomerId] INT NOT NULL,
	[OrderDate] DATETIMEOFFSET NOT NULL,
	[Discount] float,
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED (Id ASC)
);
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
	DROP TABLE [dbo].[OrderItem]
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[NumberOfItems] INT NOT NULL,
	CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED (OrderId ASC, ProductId ASC)
);
GO
-- create foreign keys
ALTER TABLE dbo.OrderItem ADD CONSTRAINT
	FK_OrderItem_OrderId FOREIGN KEY (OrderId)
		REFERENCES dbo.[Order] (Id)
GO
ALTER TABLE dbo.OrderItem ADD CONSTRAINT
	FK_OrderItem_ProductId FOREIGN KEY (ProductId)
		REFERENCES dbo.Product (Id)
GO
ALTER TABLE dbo.[Order] ADD CONSTRAINT
	FK_Order_CustomerId FOREIGN KEY (CustomerId)
		REFERENCES dbo.Customer (Id)
GO