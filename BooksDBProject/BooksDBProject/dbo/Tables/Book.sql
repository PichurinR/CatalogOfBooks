CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title]	NVARCHAR(100) NOT NULL,
	[Pages] INT	CHECK(Pages > 0) NOT NULL,
	[Rating] FLOAT CHECK(Rating >= 0 AND Rating <= 1) NOT NULL DEFAULT(0),
	[DateOfPublication] DATE NOT NULL,
)
