SELECT [R].[IdCardNumber]
FROM [Residents] AS [R]
WHERE
	NOT EXISTS
	(SELECT DISTINCT [Rents1].[RoomNumber], [Rents1].[HotelNumber]
	FROM [Rents] AS [Rents1]
	WHERE [Rents1].[Resident] = [R].[IdCardNumber] AND NOT EXISTS
		(SELECT DISTINCT [Rents2].[RoomNumber], [Rents2].[HotelNumber] 
		FROM [Rents] AS [Rents2]
		WHERE [Rents2].[Resident] = ID AND [Rents1].[RoomNumber] = [Rents2].[RoomNumber] AND [Rents1].[HotelNumber] = [Rents2].[HotelNumber]))
	AND 
	NOT EXISTS
	(SELECT DISTINCT [Rents3].[RoomNumber], [Rents3].[HotelNumber]
	FROM [Rents] AS [Rents3]
	WHERE [Rents3].[Resident] = ID AND NOT EXISTS
		(SELECT DISTINCT [Rents4].[RoomNumber], [Rents4].[HotelNumber]
		FROM [Rents] AS [Rents4]
		WHERE [Rents4].[Resident] = [R].[IdCardNumber] AND [Rents4].[RoomNumber] = [Rents3].[RoomNumber] AND [Rents4].[HotelNumber] = [Rents3].[HotelNumber]))