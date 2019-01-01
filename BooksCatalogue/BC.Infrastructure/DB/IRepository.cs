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

		T ExecuteSP(string nameSP, object param = null);
		IEnumerable<T> ExecuteSPGetList(string nameSP, object param = null);
		T ExecuteQuery(string query, object param = null);
		IEnumerable<T> ExecuteQueryGetList(string query, object param = null);
		IEnumerable<TOut> ExecuteSP<TOne, TMany, TOut>(string nameSP, Func<TOne, TMany, TOut> SetEntities, string splitOn, object param = null);

	}
}
