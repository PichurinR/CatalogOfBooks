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
        IEnumerable<AuthorEM> GetAllAuthors(long offset, long take);
        AuthorEM GetAuthor(long id);
        long CreateAuthor(AuthorEM author);
        void EditAuthor(AuthorEM author);
        void DeleteAuthor(long id);
    }
}
