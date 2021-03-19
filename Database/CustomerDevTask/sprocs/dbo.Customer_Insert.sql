IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.Customer_Insert') AND TYPE IN ('P','PC'))
	EXEC ('CREATE PROCEDURE dbo.Customer_Insert AS BEGIN RETURN; END')
GO

ALTER PROCEDURE dbo.Customer_Insert
	@FirstName VARCHAR(100),
	@Surname VARCHAR(100),
	@DateOfBirth DATE,
	@TelephoneNumber VARCHAR(255)
AS
BEGIN
	
	INSERT INTO [dbo].[Customer]
	(
		[FirstName],
		[Surname],
		[DateOfBirth]
	)
	VALUES
	(
		@FirstName,
		@Surname,
		@DateOfBirth
	);

	DECLARE @CustomerId INT = (SELECT SCOPE_IDENTITY());

	EXEC  dbo.Telephone_Insert @CustomerId = @CustomerId, @Number = @TelephoneNumber;

END