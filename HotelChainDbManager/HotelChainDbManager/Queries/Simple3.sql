SELECT "Residents"."IdCardNumber"
FROM "Residents"
JOIN "Rents" ON "Residents"."IdCardNumber" = "Rents"."Resident"
JOIN "Rooms" ON "Rents"."RoomNumber" = "Rooms"."Number" AND "Rents"."HotelNumber" = "Rooms"."HotelNumber"
JOIN "Classes" ON "Rooms"."Class" = "Classes"."Id"
WHERE "Classes"."Name" = CLASS_NAME