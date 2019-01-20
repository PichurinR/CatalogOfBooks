﻿using BC.Infrastructure.Services;
using System.Web.Mvc;
using BC.Infrastructure.DB;

namespace BooksCatalogue.Controllers
{
	
	public class HomeController : BaseController
	{
		
		private readonly IBookService _bookService;
		
		public HomeController(IBookService bookService)
		{
			_bookService = bookService;
		}
		
		public ActionResult Index()
		{
			return View();
        }

    }
}

