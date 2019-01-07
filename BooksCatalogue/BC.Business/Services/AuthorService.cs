using System.Collections.Generic;
using BC.Entity;
using BC.Infrastructure.DB;
using BC.Infrastructure.Services;
using DC.ViewModels.Author;

namespace BC.Business.Services
{
	public class AuthorService : BaseService, IAuthorService
	{
		private readonly IAuthorRepository _authorRepo;

		public AuthorService(IMappingService mapper, IAuthorRepository authorRepo) : base(mapper)
		{
			_authorRepo = authorRepo;
		}

		public long CreateAuthor(BaseAuthorVM author)
		{
			AuthorEM authorEM = _mapper.MapTo<AuthorEM>(author);
			return _authorRepo.CreateAuthor(authorEM);
		}

		public void DeleteAuthor(long id)
		{
			_authorRepo.Delete(id);
		}

		public void EditAuthor(BaseAuthorVM author)
		{
			AuthorEM authorEM = _mapper.MapTo<AuthorEM>(author);
			_authorRepo.EditAuthor(authorEM);
		}

		public IEnumerable<BaseAuthorVM> GetAllAuthors(long offset, long take)
		{
			IEnumerable<AuthorEM> authorsEM = _authorRepo.GetAllAuthors(offset, take);
			return _mapper.MapListTo<BaseAuthorVM>(authorsEM);
		}

		public AuthorInfoVM GetAuthor(long id)
		{
			var authorEM = _authorRepo.GetAuthor(id);
			return _mapper.MapTo<AuthorInfoVM>(authorEM);
		}
	}
}
