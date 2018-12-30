using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DC.ViewModels.Book;

namespace DC.ViewModels.Author 
{
    public class AuthorInfoVM : BaseAuthorVM
	{
		public List<BookInfoVM> Books { get; set; }	
    }
}
