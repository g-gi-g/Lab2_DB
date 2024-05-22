SELECT [Employees].[IdCardNumber], [Employees].[Name], [Employees].[Surname]
FROM [Employees]
JOIN [Hotels] ON [Employees].[HotelNumber] = [Hotels].[Number]
WHERE [Hotels].[Adress] = HOTEL_ADDRESS