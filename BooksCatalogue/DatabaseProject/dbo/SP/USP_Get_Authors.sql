CREATE PROCEDURE [dbo].[USP_Get_Authors]
	@offset BIGINT = 0,
	@take	BIGINT = 10
AS
	SELECT 	a.[Id], a.LastName FROM [Authors] as a
	LEFT JOIN [AuthorBook]	AS [ba] ON ba.[AuthorId] = a.[Id]
	GROUP BY [a].[Id], a.[LastName], a.[FirstName]
	ORDER BY a.[LastName], a.[FirstName],COUNT([ba].[AuthorId])
	OFFSET @offset ROW
	FETCH NEXT @take ROWS ONLY 
	
RETURN 0
