using BC.Infrastructure.Services;

namespace BC.Business.Services
{
	public abstract class BaseService
	{
		protected readonly IMappingService _mapper;

		protected BaseService(IMappingService mapper)
		{
			_mapper = mapper;
		}
	}
}
