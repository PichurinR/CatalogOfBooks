using System.Collections.Generic;
using DC.ViewModels.Book;

namespace BC.Infrastructure.Services
{
	public interface IBookService
	{
		long CreateBook(BookCreateVM book);
		IEnumerable<BookInfoVM> GetAllBooks(long offset, long take);
		BookInfoVM GetBook(long id);
		void EditBook(BookCreateVM book);
		void DeleteBook(long id);
	}
}
