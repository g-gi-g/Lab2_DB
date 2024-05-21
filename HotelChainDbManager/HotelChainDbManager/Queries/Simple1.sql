SELECT "Rooms"."Number"
FROM "Rooms"
WHERE "Rooms"."HotelNumber" = HOTEL_NUMBER AND "Rooms"."Class" IN
	(SELECT "Classes"."ClassId"
	FROM "Classes"
	WHERE "Classes"."Name" = CLASS_NAME)
