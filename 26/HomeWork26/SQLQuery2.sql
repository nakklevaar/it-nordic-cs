--CREATE DATABASE AirportInfo1
GO
USE AirportInfo1
GO
DROP TABLE IF EXISTS [dbo].[DepartureBoard]
GO
CREATE TABLE dbo.DepartureBoard (
	RaceId UNIQUEIDENTIFIER NOT NULL,
	DepartureCountry VARCHAR(30) NOT NULL,
	DepartureCity VARCHAR(30) NOT NULL,
	DepartureTime DATETIMEOFFSET NOT NULL,
	ArrivalCountry VARCHAR(30) NOT NULL,
	ArrivalCity VARCHAR(30) NOT NULL,
	ArrivalTime DATETIMEOFFSET NOT NULL,
	FlightTimeMinutes INT NOT NULL,
	Company VARCHAR(30) NOT NULL,
	PlaneModel VARCHAR(30),
	CONSTRAINT PK_DepartureBoard PRIMARY KEY CLUSTERED (RaceId ASC) 
);
GO

EXECUTE dbo.CreateRace 
	@departureCountry = 'Russia',
	@departureCity = 'Moscow',
	@departureTime = '2007-05-06 12:10:09',
	@arrivalCountry = 'USA',
	@arrivalCity = 'LA',
	@arrivalTime = '2007-05-07 12:10:09',
	@company = 'FLOT1',
	@planeModel = 'S1';

EXECUTE dbo.CreateRace 
	@departureCountry = 'USA',
	@departureCity = 'LA',
	@departureTime = '2017-10-06 12:10:09',
	@arrivalCountry = 'Russia',
	@arrivalCity = 'Moscow',
	@arrivalTime = '2017-10-06 16:10:09',
	@company = 'flot2',
	@planeModel = 'RS';

SELECT * FROM dbo.DepartureBoard