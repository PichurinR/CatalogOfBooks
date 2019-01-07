using BC.Infrastructure.Services;
using System.Collections.Generic;
using AutoMapper;

namespace BC.Business.Services
{
	public class MappingService : IMappingService
	{
		private readonly IMapper _mapper;

		public MappingService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<TDest> MapListTo<TDest>(object source)
		{
			return _mapper.Map<IEnumerable<TDest>>(source);
		}

		public TDest MapTo<TDest>(object source)
		{
			return _mapper.Map<TDest>(source);
		}
	}
}
