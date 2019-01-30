using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ViewModels.Book
{
	public class BaseBookVM
	{
		public long Id { get; set; }
		[Display(Name = "Title"), Required]
		public string Title { get; set; }
		[Display(Name = "Pages"), Required]
		public int Pages { get; set; }
		[Display(Name = "Date of publication"), Required]
		public DateTime DateOfPublication { get; set; }
		[Display(Name = "Rating"), Required]
		public int Rating { get; set; }
	}
}
