using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ViewModels.Book;

namespace BC.Infrastructure.Services
{
	public interface IBookService
	{
		long CreateBook(BaseBookVM book);
		IEnumerable<BaseBookVM> GetAllBooks(long offset, long take);
		BookInfoVM GetBook(long id);
		void EditBook(BaseBookVM author);
		void DeleteBook(long id);
	}
}
