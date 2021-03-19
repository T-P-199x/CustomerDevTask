IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.Customer_GetById') AND TYPE IN ('P','PC'))
	EXEC ('CREATE PROCEDURE dbo.Customer_GetById AS BEGIN RETURN; END')
GO

ALTER PROCEDURE dbo.Customer_GetById
	@CustomerId INT
AS
BEGIN
	
	SELECT
		C.ID,
		C.[FirstName],
		C.[Surname],
		C.[DateOfBirth],
		T.[Number] AS [TelephoneNumber]
	FROM [dbo].[Customer] C
	LEFT JOIN [dbo].[Telephone] T ON C.[ID] = T.[CustomerId]
	WHERE C.[ID] = @CustomerId;

END