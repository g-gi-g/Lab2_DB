SELECT "Employees"."IdCardNumber"
FROM "Employees"
WHERE NOT EXISTS 
	(SELECT "Rents"."RoomNumber"
	FROM "Rents"
	WHERE "Rents"."HotelNumber" <> "Employees"."HotelNumber")
AND "Employees"."CompanyPosition" IN 
	(SELECT "CompanyPositions"."Id"
	FROM "CompanyPositions"
	WHERE "CompanyPositions"."Name" = POS_NAME)
