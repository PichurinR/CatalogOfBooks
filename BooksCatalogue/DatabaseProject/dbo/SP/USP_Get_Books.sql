CREATE PROCEDURE [dbo].[USP_Get_Books]
	@offset BIGINT = 0,
	@take	BIGINT = 10
AS
	SELECT b.[Id], b.[Title], b.[Pages], b.[Rating],b.[DateOfPublication],
		   a.[Id], a.[FirstName], a.[LastName]
	
	FROM [Books] AS b
	JOIN AuthorBook AS ba ON ba.[BookId] = b.[Id]
	JOIN [Authors] AS a ON a.[Id] = ba.[AuthorId]
	ORDER BY [b].[Title]
	OFFSET @offset ROWS
	FETCH NEXT @take ROWS ONLY
	
RETURN 0
