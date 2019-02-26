using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Entity;
using BC.Entity.Enums;
using BC.Infrastructure.DB;
using BC.Infrastructure.Extensions;
using Dapper;


namespace BC.Data.Repositories
{
	public class BookRepository : DapperRepository<BookEM>, IBookRepository
	{
		public BookRepository(IDbContext dbContext) : base(dbContext)
		{
		}

		public int CreateBook(BookEM book)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@Title", book.Title);
			parameters.Add("@Pages", book.Pages);
			parameters.Add("@DateOfPublication", book.DateOfPublication);
			parameters.Add("@AuthorsIds", book.Authors.Select(a => a.Id).AsDataTableParam().AsTableValuedParameter(DataBaseCustomType.BigIntArrayType));

			parameters.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.ReturnValue);

			ExecuteSP("USP_Insert_Book", parameters);
			return parameters.Get<int>("@Id");
		}

		public void DeleteBook(long id)
		{
			Delete(id);
		}

		public void EditBook(BookEM book)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@Id", book.Id);
			parameters.Add("@Title", book.Title);
			parameters.Add("@Pages", book.Pages);
			parameters.Add("@DateOfPublication", book.DateOfPublication);
			parameters.Add("@AuthorsIds", book.Authors.Select(a => a.Id).AsDataTableParam().AsTableValuedParameter(DataBaseCustomType.BigIntArrayType));

			parameters.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.ReturnValue);

			ExecuteSP("USP_Update_Book", parameters);
		}

		public IEnumerable<BookEM> GetAllBooks(long offset, long take)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@offset", offset);
			parameters.Add("@take", take);

			return GetBooks("USP_Get_Books", parameters);
		}

		public BookEM GetBook(long id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@Id", id);

			return GetBooks("USP_Get_Book", parameters).FirstOrDefault();
		}

		private IEnumerable<BookEM> GetBooks(string spName, DynamicParameters parameters)
		{
			var booksDictionary = new Dictionary<long, BookEM>();

			return ExecuteSP<BookEM, AuthorEM, BookEM>(spName,
				(book, author) =>
				{
					if (!booksDictionary.TryGetValue(book.Id, out BookEM bookEntry))
					{
						bookEntry = book;
						bookEntry.Authors = new List<AuthorEM>();
						booksDictionary.Add(book.Id, bookEntry);
					}

					bookEntry.Authors.AsList().Add(author);
					return bookEntry;
				}, "Id", parameters).Distinct();
		}
	}
}
