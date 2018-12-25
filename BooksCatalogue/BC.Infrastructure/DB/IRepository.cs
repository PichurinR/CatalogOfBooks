using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.DB
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        long Insert(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
