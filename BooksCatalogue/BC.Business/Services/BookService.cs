using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Infrastructure.DB;
using BC.Infrastructure.Services;
using DC.ViewModels.Book;

namespace BC.Business.Services
{
	public class BookService : BaseService, IBookService
	{
		private readonly IBookRepository _bookRepo;

		public BookService(IMappingService mapper, IBookRepository bookRepo) : base(mapper)
		{
			_bookRepo = bookRepo
		}
		public long CreateBook(BaseBookVM book)
		{
			throw new NotImplementedException();
		}

		public void DeleteBook(long id)
		{
			throw new NotImplementedException();
		}

		public void EditBook(BaseBookVM author)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<BaseBookVM> GetAllBooks(long offset, long take)
		{
			throw new NotImplementedException();
		}

		public BookInfoVM GetBook(long id)
		{
			throw new NotImplementedException();
		}
	}
}
