using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksCatalogue.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        [HandleError(View = "Error")]
		public ActionResult Index()
        {
	       return View();
        }

    }
}

