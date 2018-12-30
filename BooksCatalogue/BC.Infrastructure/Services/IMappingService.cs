using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Infrastructure.Services
{
	public interface IMappingService
	{
		TDest MapTo<TDest>(object source);
		IEnumerable<TDest> MapListTo<TDest>(object source);
	}
}
