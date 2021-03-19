IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.Customer_Update') AND TYPE IN ('P','PC'))
	EXEC ('CREATE PROCEDURE dbo.Customer_Update AS BEGIN RETURN; END')
GO

ALTER PROCEDURE dbo.Customer_Update
	@CustomerId INT,
	@FirstName VARCHAR(100),
	@Surname VARCHAR(100),
	@DateOfBirth DATE,
	@TelephoneNumber VARCHAR(255)
AS
BEGIN
	
	UPDATE [dbo].[Customer]
	SET
		[FirstName] = @FirstName,
		[Surname] = @Surname,
		[DateOfBirth] = @DateOfBirth
	WHERE [ID] = @CustomerId;

	EXEC [dbo].[Telephone_UpdateByCustomerId] @CustomerId = @CustomerId, @TelephoneNumber = @TelephoneNumber;

END