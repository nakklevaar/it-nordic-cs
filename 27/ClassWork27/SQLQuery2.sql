INSERT INTO dbo.City(Id, [Name])
	VALUES (1, 'Москва')

INSERT INTO dbo.City(Id, [Name])
	VALUES (2, 'Санкт-Петербург')

INSERT INTO dbo.Adress(Id,CityId,Adress)
	VALUES (1,1, 'ул.Большая садовая, д.10')

DELETE FROM dbo.Adress
WHERE Id = 1