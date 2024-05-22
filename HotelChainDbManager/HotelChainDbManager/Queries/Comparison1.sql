SELECT [R].[Number], [R].[HotelNumber]
FROM [Rooms] AS [R]
WHERE NOT EXISTS
	(SELECT DISTINCT [Rents].[Resident]
	FROM [Rents]
	JOIN [Rooms] ON [Rooms].[Number] = [Rents].[RoomNumber] AND [Rooms].[HotelNumber] = [Rents].[HotelNumber]
	WHERE [Rooms].[Number] = ROOM_NUMBER AND [Rooms].[HotelNumber] = HOTEL_NUMBER AND [Rents].[Resident] NOT IN
		(SELECT DISTINCT [Rents].[Resident]
		FROM [Rents]
		JOIN [Rooms] ON [Rooms].[Number] = [Rents].[RoomNumber] AND [Rooms].[HotelNumber] = [Rents].[HotelNumber]
		WHERE [Rooms].[Number] = [R].[Number] AND [Rooms].[HotelNumber] = [R].[HotelNumber]))
	AND NOT EXISTS
	(SELECT DISTINCT [Rents].[Resident]
	FROM [Rents]
	JOIN [Rooms] ON [Rooms].[Number] = [Rents].[RoomNumber] AND [Rooms].[HotelNumber] = [Rents].[HotelNumber]
	WHERE [Rooms].[Number] = [R].[Number] AND [Rooms].[HotelNumber] = [R].[HotelNumber] AND [Rents].[Resident] NOT IN
		(SELECT DISTINCT [Rents].[Resident]
		FROM [Rents]
		JOIN [Rooms] ON [Rooms].[Number] = [Rents].[RoomNumber] AND [Rooms].[HotelNumber] = [Rents].[HotelNumber]
		WHERE [Rooms].[Number] = ROOM_NUMBER AND [Rooms].[HotelNumber] = HOTEL_NUMBER))
