using System.Linq;
using System.Web.Mvc;
using BC.Infrastructure.Services;

namespace BooksCatalogue.Controllers
{
    public class BookController : BaseController
    {
	    private readonly IBookService _bookService;

	    public BookController(IBookService bookService)
	    {
		    _bookService = bookService;
	    }
		// GET: Book
		[HttpGet]
		public ActionResult GetBooks()
        {
			var books = _bookService.GetAllBooks(1,10).ToList();
			return Json(new { data = books }, JsonRequestBehavior.AllowGet);
		}

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
