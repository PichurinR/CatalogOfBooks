using System.Web.Mvc;
using AutoMapper;
using BC.Business.Services;
using BC.Data.DbContext;
using BC.Data.Repositories;
using BC.Infrastructure.DB;
using BC.Infrastructure.Services;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace BC.Bootstrap
{
    public static class UnityConfig
	{
		public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IDbContext, DbContext>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IMappingService, MappingService>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IAuthorService, AuthorService>();
			container.RegisterInstance<IMapper>(ApplicationMapper.Mapper, new ContainerControlledLifetimeManager());

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
    }
}
