﻿CREATE PROCEDURE [dbo].[USP_Insert_Book]
        @Title NVARCHAR(100),
        @Pages INT,
        @DateOfPublication DATE,
		@AuthorsIds BigIntArrayType READONLY
AS 
BEGIN TRANSACTION

	DECLARE @TempBookTable TABLE (Id BIGINT)
	DECLARE @TempBookTableId BIGINT

	INSERT INTO [Books]([Title], [Pages], [DateOfPublication])
		OUTPUT INSERTED.Id INTO @TempBookTable
		VALUES (@Title, @Pages, @DateOfPublication)

	SET @TempBookTableId = (SELECT TOP 1 [Id] FROM @TempBookTable)

	INSERT INTO [AuthorBook] ([BookId], [AuthorId])
		SELECT b.[Id], a.[Item]
		FROM @TempBookTable AS b, @AuthorsIds AS a

COMMIT TRANSACTION

RETURN @TempBookTableId
