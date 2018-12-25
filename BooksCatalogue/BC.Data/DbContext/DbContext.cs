using BC.Infrastructure.DB;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BC.Data.DbContext
{
    public class DbContext : IDbContext
    {
        public string ConnectionString { get; private set; }
        public DbContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString;
        }
       
        public void CallInstructions(Action<IDbConnection> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                action(db);
            }
        }

        public T CallInstructions<T>(Func<IDbConnection, T> func)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return func(db);
            }
        }
    }
}
