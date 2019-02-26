using System.Linq;
using AutoMapper;
using BC.Entity;
using DC.ViewModels.Author;
using DC.ViewModels.Book;

namespace BC.Bootstrap
{
    public static class ApplicationMapper
    {
        public static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<BookEM, BaseBookVM>().ReverseMap();
                    cfg.CreateMap<BookEM, BookInfoVM>().ReverseMap();
                    cfg.CreateMap<BookCreateVM, BookEM>();
                    cfg.CreateMap<AuthorEM, BaseAuthorVM>().ReverseMap();
                    cfg.CreateMap<AuthorEM, AuthorInfoVM>().ReverseMap();
                    cfg.CreateMap<BookCreateVM, BookEM>()
                        .ForMember(dest => dest.Authors, opt =>opt.MapFrom(src => src.AuthorIds.Select(id => new AuthorEM { Id = id })));
                });

            return config.CreateMapper();
        }
    }
}
