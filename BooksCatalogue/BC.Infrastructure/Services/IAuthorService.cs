using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ViewModels.Author;

namespace BC.Infrastructure.Services
{
	public interface IAuthorService
	{
		long CreateAuthor(BaseAuthorVM author);
		IEnumerable<BaseAuthorVM> GetAllAuthors(long offset, long take);
		AuthorInfoVM GetAuthor(long id);
		void EditAuthor(BaseAuthorVM author);
		void DeleteAuthor(long id);
	}
}
