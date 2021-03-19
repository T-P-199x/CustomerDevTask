IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.Telephone_UpdateByCustomerId') AND TYPE IN ('P','PC'))
	EXEC ('CREATE PROCEDURE dbo.Telephone_UpdateByCustomerId AS BEGIN RETURN; END')
GO

ALTER PROCEDURE dbo.Telephone_UpdateByCustomerId
	@CustomerId INT,
	@TelephoneNumber VARCHAR(255)
AS
BEGIN
	
	UPDATE [dbo].[Telephone]
	SET
		[Number] = @TelephoneNumber
	WHERE [CustomerId] = @CustomerId;

END