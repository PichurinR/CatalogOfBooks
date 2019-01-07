using BC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.DB
{
    public interface IBookRepository : IRepository<BookEM>
    {
		IEnumerable<BookEM> GetAllBooks(long offset, long take);
		BookEM GetBook(long id);
        long CreateBook(BookEM book);
        void EditBook(BookEM book);
        void DeleteBook(long id);
    }
}
