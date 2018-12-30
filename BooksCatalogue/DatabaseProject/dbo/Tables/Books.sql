CREATE TABLE [dbo].[Books]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Title]	NVARCHAR(100) NOT NULL,
	[Pages] INT	CHECK(Pages > 0) NOT NULL,
	[Rating] INT CHECK(Rating >= 0 AND Rating <= 10) NOT NULL DEFAULT(0),
	[DateOfPublication] DATE NOT NULL
)
