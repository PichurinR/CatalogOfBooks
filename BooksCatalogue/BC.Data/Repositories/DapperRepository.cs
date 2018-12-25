using BC.Infrastructure.DB;
using System;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BC.Data.Repositories
{
    public abstract class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _dbContext;

        protected DapperRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(long id)
        {
            _dbContext.CallInstructions(db =>
            {
                var entity = db.Get<T>(id);
                db.Delete(entity);
            });

        }

        public T Get(long id)
        {
            return _dbContext.CallInstructions(db => db.Get<T>(id));
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.CallInstructions(db => db.GetAll<T>());
        }

        public long Insert(T entity)
        {
            return _dbContext.CallInstructions(db => db.Insert(entity));
        }

        public void Update(T entity)
        {
            _dbContext.CallInstructions(db => db.Update(entity));
        }
    }
}
