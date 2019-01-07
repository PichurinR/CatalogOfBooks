using System;
using System.Linq;
using AutoMapper;
using BC.Entity;
using DC.ViewModels.Author;
using DC.ViewModels.Book;

namespace BC.Bootstrap
{
	public static class ApplicationMapper
	{
		private static readonly Lazy<IMapper> _mapper;

		public static IMapper Mapper => _mapper.Value;

		static ApplicationMapper()
		{
			if (_mapper == null)
			{
				_mapper = new Lazy<IMapper>(ConfigureMapper);
			}
		}

		private static IMapper ConfigureMapper()
		{
			var config = new MapperConfiguration(MappingConfiguration);

			config.AssertConfigurationIsValid();
			return config.CreateMapper();
		}

		private static void MappingConfiguration(IMapperConfigurationExpression configure)
		{
			AutoMapper.Mapper.Initialize((mapper) =>
				{
					mapper.CreateMap<BookEM, BaseBookVM>().ReverseMap();
					mapper.CreateMap<BookEM, BookInfoVM>().ReverseMap();
					mapper.CreateMap<BookCreateVM, BookEM>()
						.ForMember(dest => dest.Authors,
							opt => opt.MapFrom(src => src.AuthorIds
								.Select(id => new AuthorEM { Id = id })));

					mapper.CreateMap<AuthorEM, BaseAuthorVM>().ReverseMap();
					mapper.CreateMap<AuthorEM, AuthorInfoVM>().ReverseMap();
			});
		}
	}
}
