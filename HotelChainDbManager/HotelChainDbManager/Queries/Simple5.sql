SELECT "Employees"."IdCardNumber", "Employees"."Name", "Employees"."Surname"
FROM "Employees"
JOIN "CompanyPositions" ON "Employees"."CompanyPosition" = "CompanyPositions"."Id"
WHERE "CompanyPositions"."WorkingRate" = RATE