using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DC.ViewModels.Book
{
	public class BookCreateVM : BaseBookVM
	{
		[Display(Name = "Authors"),Required]
		public IEnumerable<long> AuthorIds { get; set; }
	}
}
