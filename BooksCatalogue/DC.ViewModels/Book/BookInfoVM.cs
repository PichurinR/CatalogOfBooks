using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ViewModels.Author;

namespace DC.ViewModels.Book
{
	public class BookInfoVM : BaseBookVM
	{
		public int Rating { get; set; }
		public List<BaseAuthorVM> Authors { get; set; }
	}
}
