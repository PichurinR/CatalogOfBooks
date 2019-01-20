using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksCatalogue.Filters;

namespace BooksCatalogue.Controllers
{
	[LogExceptionFilter]
	public class BaseController : Controller
	{
	}
}