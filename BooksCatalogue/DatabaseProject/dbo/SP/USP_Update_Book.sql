CREATE PROCEDURE [dbo].[USP_Update_Book]
        @Id BIGINT,
	    @Title NVARCHAR(100),
        @Pages INT,
        @DateOfPublication DATE,
		@AuthorsIds BigIntArrayType READONLY
AS 
BEGIN TRANSACTION;
BEGIN TRY
	UPDATE [Books] SET
		   [Title] = @Title,
		   [Pages] = @Pages,
		   [DateOfPublication] = @DateOfPublication
	WHERE [Books].[Id] = @Id

	DELETE FROM [AuthorBook]
	WHERE [AuthorBook].[BookId] = @Id AND [AuthorBook].[AuthorId] 
			NOT IN (SELECT * FROM @AuthorsIds)
	
	DECLARE @insertAuthors BigIntArrayType
	INSERT INTO @insertAuthors
	SELECT [Item] FROM @AuthorsIds 
	WHERE [Item] NOT IN (SELECT [ba].[AuthorId] 
	FROM [AuthorBook] AS ba WHERE ba.[BookId] = @Id)
	
INSERT INTO AuthorBook([AuthorId],[BookId])
		SELECT @Id, a.[Item]
		FROM @insertAuthors AS a

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
    END;
   
    ;THROW
END CATCH;
IF @@TRANCOUNT > 0
    BEGIN
       COMMIT TRANSACTION;
    END;
RETURN 0

