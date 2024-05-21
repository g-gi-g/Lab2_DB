SELECT "R"."Number", "R"."HotelNumber"
FROM "Rooms" AS "R"
WHERE 
	((SELECT "Rents"."Resident"
	FROM "Rents"
	JOIN "Rooms" ON "Rooms"."Number" = "Rents"."RoomNumber" AND "Rooms"."HotelNumber" = "Rents"."HotelNumber"
	WHERE "Rooms"."Number" = ROOM_NUMBER AND "Rooms"."HotelNumber" = HOTEL_NUMBER)
	=
	(SELECT "Rents"."Resident"
	FROM "Rents"
	JOIN "Rooms" ON "Rooms"."Number" = "Rents"."RoomNumber" AND "Rooms"."HotelNumber" = "Rents"."HotelNumber"
	WHERE "Rooms"."Number" = "R"."Number" AND "Rooms"."HotelNumber" = "R"."HotelNumber"))
	
