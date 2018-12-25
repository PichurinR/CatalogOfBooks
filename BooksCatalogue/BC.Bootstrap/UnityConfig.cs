using BC.Data.DbContext;
using BC.Infrastructure.DB;
using Unity;
namespace BC.Bootstrap
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IDbContext, DbContext>();
        }
    }
}
