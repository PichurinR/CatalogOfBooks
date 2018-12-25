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
    public class BookRepository : DapperRepository<BookEM>, IBookRepository
    {
        public BookRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public long CreateBook(BookEM book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(long id)
        {
            throw new NotImplementedException();
        }

        public void EditBook(BookEM book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookEM> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public BookEM GetBook(long id)
        {
            throw new NotImplementedException();
        }
    }
}
