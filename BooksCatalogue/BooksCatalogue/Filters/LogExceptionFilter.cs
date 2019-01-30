using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksCatalogue.Filters
{
	public class LogExceptionFilter : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext filterContext)
		{
			if (!filterContext.ExceptionHandled)
			{
				//filterContext.Result = new RedirectResult("/Content/Error/Error.html");
				filterContext.ExceptionHandled = true;
			}
		}
	}
}