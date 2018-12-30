using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ViewModels.Book
{
	public class BaseBookVM
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public int Pages { get; set; }
		public DateTime DateOfPublication { get; set; }
	}
}
