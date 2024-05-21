SELECT "Employees"."IdCardNumber", "Employees"."Name", "Employees"."Surname"
FROM "Employees"
WHERE "Employees"."Hotels" = HOTEL AND "Employees"."CompanyPosition" IN
(SELECT "CompanyPositions"."Id"
FROM "CompanyPositions"
WHERE "CompanyPositions"."Name" = POS_NAME)
