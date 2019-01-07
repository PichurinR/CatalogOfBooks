CREATE PROCEDURE [dbo].[USP_Get_Book]
	@id BIGINT
AS 
	SELECT b.[Id], b.[Title], b.[Pages], b.[Rating],b.[DateOfPublication],
		   a.[Id], a.[FirstName], a.[LastName]
	
	FROM [Books] AS b
	JOIN AuthorBook AS ba ON ba.[BookId] = b.[Id]
	JOIN [Authors] AS a ON a.[Id] = ba.[AuthorId]

RETURN 0