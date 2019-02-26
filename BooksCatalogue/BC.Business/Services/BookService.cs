﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BC.Entity;
using BC.Infrastructure.DB;
using BC.Infrastructure.Services;
using DC.ViewModels.Book;

namespace BC.Business.Services
{
	public class BookService : BaseService, IBookService
	{
        private static IMappingService _mapper;
        private readonly IBookRepository _bookRepo;
    
		public BookService(IMappingService mapper, IBookRepository bookRepo) : base(mapper)
		{
			_bookRepo = bookRepo;
            _mapper = mapper;
        }
		public long CreateBook(BookCreateVM book)
		{
            //var config = new MapperConfiguration(
            //    cfg =>
            //        cfg.CreateMap<BookCreateVM, BookEM>()
            //            .ForMember(dest => dest.Authors, opt =>
            //                 opt.MapFrom(src => src.AuthorIds.Select(id => new AuthorEM { Id = id }))));


            //var mapper = config.CreateMapper();

            BookEM bookEM = _mapper.MapTo<BookEM>(book);
			return _bookRepo.CreateBook(bookEM);
		}

		public void DeleteBook(long id)
		{
			_bookRepo.DeleteBook(id);
		}

		public void EditBook(BookCreateVM book)
		{
			BookEM bookEM = _mapper.MapTo<BookEM>(book);
			_bookRepo.EditBook(bookEM);
		}

		public IEnumerable<BookInfoVM> GetAllBooks(long offset, long take)
		{
			IEnumerable<BookEM> booksEM = _bookRepo.GetAllBooks(offset, take);
			var res = _mapper.MapListTo<BookInfoVM>(booksEM);
			return res;
		}

		public BookInfoVM GetBook(long id)
		{
			BookEM bookEM = _bookRepo.GetBook(id);
			return _mapper.MapTo<BookInfoVM>(bookEM);
		}
	}
}
