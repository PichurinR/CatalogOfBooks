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

        public long CreateAuthor(AuthorEM book)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(long id)
        {
            throw new NotImplementedException();
        }

        public void EditAuthor(AuthorEM book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorEM> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public AuthorEM GetAuthor(long id)
        {
            throw new NotImplementedException();
        }
    }
}
