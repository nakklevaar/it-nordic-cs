USE [AirportInfo1]
GO
DROP PROCEDURE IF EXISTS [dbo].[CreateRace]
GO
CREATE PROCEDURE dbo.CreateRace (
	@departureCountry VARCHAR(30),
	@departureCity VARCHAR(30),
	@departureTime DATETIMEOFFSET,
	@arrivalCountry VARCHAR(30),
	@arrivalCity VARCHAR(30),
	@arrivalTime DATETIMEOFFSET,
	@company VARCHAR(30),
	@planeModel VARCHAR(30)
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @guid AS UNIQUEIDENTIFIER
	SET @guid = NEWID()

	DECLARE @flightTime AS INT
	SET @flightTime = DATEDIFF(MINUTE, @departureTime,@arrivalTime) 

	INSERT INTO dbo.DepartureBoard (
		RaceId,
		DepartureCountry,
		DepartureCity,
		DepartureTime,
		ArrivalCountry,
		ArrivalCity,
		ArrivalTime,
		FlightTimeMinutes,
		Company,
		PlaneModel
	)
	VALUES (
		@guid,
		@departureCountry,
		@departureCity,
		@departureTime,
		@arrivalCountry,
		@arrivalCity,
		@arrivalTime,
		@flightTime,
		@company,
		@planeModel
	);
END
GO

