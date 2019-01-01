using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Entity;
using BC.Infrastructure.DB;
using Dapper;


namespace BC.Data.Repositories
{
	public class AuthorRepository : DapperRepository<AuthorEM>, IAuthorRepository
	{
		public AuthorRepository(IDbContext dbContext) : base(dbContext)
		{
		}

		public long CreateAuthor(AuthorEM author)
		{
			return Insert(author);
		}

		public void DeleteAuthor(long id)
		{
			Delete(id);
		}

		public void EditAuthor(AuthorEM author)
		{
			Update(author);
		}

		public IEnumerable<AuthorEM> GetAllAuthors(long offset, long take)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@take", take);
			parameters.Add("@offset", offset);
			
			return ExecuteSPGetList("USP_Get_Authors", parameters).Distinct();
		}
		
		public AuthorEM GetAuthor(long id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			var authorsDictionary = new Dictionary<long, AuthorEM>();

			return ExecuteSP<AuthorEM, BookEM, AuthorEM>("USP_Get_Author",
				(author, book) =>
				{
					if (!authorsDictionary.TryGetValue(author.Id, out AuthorEM authorEntry))
					{
						authorEntry = author;
						authorEntry.Books = new List<BookEM>();
						authorsDictionary.Add(author.Id, authorEntry);
					}

					authorEntry.Books.Add(book);
					return authorEntry;
				}, "Id", parameters)
				.Distinct().FirstOrDefault();
		}
	}
}
