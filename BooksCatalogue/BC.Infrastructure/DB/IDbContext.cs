using System;
using System.Data;

namespace BC.Infrastructure.DB
{
    public interface IDbContext
    {
        string ConnectionString { get; }

        void CallInstructions(Action<IDbConnection> action);
        T CallInstructions<T>(Func<IDbConnection, T> func);
    }
}
