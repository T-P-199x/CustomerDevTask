IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('dbo.Telephone_Insert') AND TYPE IN ('P','PC'))
	EXEC ('CREATE PROCEDURE dbo.Telephone_Insert AS BEGIN RETURN; END')
GO

ALTER PROCEDURE dbo.Telephone_Insert
	@CustomerId INT,
	@Number VARCHAR(255)
AS
BEGIN
	
	INSERT INTO [dbo].[Telephone]
	(
		[CustomerId],
		[Number]
	)
	VALUES
	(
		@CustomerId,
		@Number
	);

END