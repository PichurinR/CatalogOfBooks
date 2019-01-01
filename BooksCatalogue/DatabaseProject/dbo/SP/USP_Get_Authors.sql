CREATE PROCEDURE [dbo].[USP_Author_GetList]
	@offset BIGINT = 0,
	@take	BIGINT = 10
AS
	SELECT 	a.[Id], a.LastName FROM [Authors] as a
	LEFT JOIN [AuthorBook]	AS [ba] ON ba.[AuthorId] = a.[Id]
	ORDER BY a.[LastName], a.[FirstName]
	OFFSET @offset ROW
	FETCH NEXT @take ROWS ONLY 

RETURN 0
