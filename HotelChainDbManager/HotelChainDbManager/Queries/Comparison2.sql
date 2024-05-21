SELECT "R"."IdCardNumber"
FROM "Residents" AS "R"
WHERE
	((SELECT "Rents"."RoomNumber", "Rents"."HotelNumber"
	FROM "Rents"
	WHERE "Rents"."Resident" = "R"."IdCardNumber")
	=
	(SELECT "Rents"."RoomNumber", "Rents"."HotelNumber"
	FROM "Rents"
	WHERE "Rent"."Resident" = ID))