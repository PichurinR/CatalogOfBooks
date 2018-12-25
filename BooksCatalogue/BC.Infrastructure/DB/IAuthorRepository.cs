using BC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.DB
{
    public interface IAuthorRepository : IRepository<AuthorEM>
    {
        IEnumerable<AuthorEM> GetAllAuthors();
        AuthorEM GetAuthor(long id);
        long CreateAuthor(AuthorEM book);
        void EditAuthor(AuthorEM book);
        void DeleteAuthor(long id);
    }
}
