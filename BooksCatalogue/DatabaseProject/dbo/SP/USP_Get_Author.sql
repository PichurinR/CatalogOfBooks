CREATE PROCEDURE [dbo].[USP_Get_Author]
	@id INT
AS 
	SELECT a.[Id], a.[FirstName], a.[LastName],
	b.[Id], b.[Title], b.[Pages], b.[Rating],b.[DateOfPublication]	

	FROM [Authors] AS a
	LEFT JOIN [AuthorBook] AS ab ON ab.[AuthorId] = a.[Id]
	LEFT JOIN [Books] AS b on b.[Id] = b.[Id]
	WHERE [a].[Id] = @Id
	ORDER BY b.[Title]

RETURN 0
