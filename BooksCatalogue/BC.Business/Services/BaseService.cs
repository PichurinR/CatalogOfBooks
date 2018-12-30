using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Infrastructure.Services;

namespace BC.Business.Services
{
	public abstract class BaseService
	{
		protected readonly IMappingService _mapper;

		public BaseService(IMappingService mapper)
		{
			_mapper = mapper;
		}
	}
}
