SELECT [Employees].[IdCardNumber]
FROM [Employees]
WHERE NOT EXISTS 
	(SELECT [Services].[RoomNumber]
	FROM [Services]
	WHERE [Employees].[IdCardNumber] = [Services].[EmployeeId] AND [Services].[HotelNumber] <> [Employees].[HotelNumber])
AND [Employees].[CompanyPosition] IN 
	(SELECT [CompanyPositions].[Id]
	FROM [CompanyPositions]
	WHERE [CompanyPositions].[Name] = POS_NAME)
