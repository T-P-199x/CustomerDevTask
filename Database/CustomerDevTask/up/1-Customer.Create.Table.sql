CREATE TABLE [Customer]
(
	[ID]  INT NOT NULL IDENTITY(1,1)
		PRIMARY KEY CLUSTERED,
	[FirstName] VARCHAR(100) NOT NULL,
	[Surname] VARCHAR(100) NOT NULL,
	[DateOfBirth] DATE NOT NULL
);