using System.Collections.Generic;
using BC.Entity;
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
			_bookRepo = bookRepo;
		}
		public long CreateBook(BookCreateVM book)
		{
			BookEM bookEM = _mapper.MapTo<BookEM>(book);
			return _bookRepo.CreateBook(bookEM);
		}

		public void DeleteBook(long id)
		{
			_bookRepo.DeleteBook(id);
		}

		public void EditBook(BookCreateVM book)
		{
			BookEM bookEM = _mapper.MapTo<BookEM>(book);
			_bookRepo.EditBook(bookEM);
		}

		public IEnumerable<BookInfoVM> GetAllBooks(long offset, long take)
		{
			IEnumerable<BookEM> booksEM = _bookRepo.GetAllBooks(offset, take);
			return _mapper.MapListTo<BookInfoVM>(booksEM);
		}

		public BookInfoVM GetBook(long id)
		{
			BookEM bookEM = _bookRepo.GetBook(id);
			return _mapper.MapTo<BookInfoVM>(bookEM);
		}
	}
}
