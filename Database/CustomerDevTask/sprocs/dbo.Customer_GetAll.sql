IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.Customer_GetAll') AND TYPE IN ('P','PC'))
	EXEC ('CREATE PROCEDURE dbo.Customer_GetAll AS BEGIN RETURN; END')
GO

ALTER PROCEDURE dbo.Customer_GetAll
AS
BEGIN
	
	SELECT
		C.ID,
		C.[FirstName],
		C.[Surname],
		C.[DateOfBirth],
		T.[Number] AS [TelephoneNumber]
	FROM [dbo].[Customer] C
	LEFT JOIN [dbo].[Telephone] T ON C.[ID] = T.[CustomerId];

END