INSERT INTO dbo.City(Id, [Name])
	VALUES (1, '������')

INSERT INTO dbo.City(Id, [Name])
	VALUES (2, '�����-���������')

INSERT INTO dbo.Adress(Id,CityId,Adress)
	VALUES (1,1, '��.������� �������, �.10')

DELETE FROM dbo.Adress
WHERE Id = 1