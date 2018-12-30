using System.Collections.Generic;

namespace DC.ViewModels.Book
{
	public class BookCreateVM : BaseBookVM
	{
		public List<long> AuthorIds { get; set; }
	}
}
