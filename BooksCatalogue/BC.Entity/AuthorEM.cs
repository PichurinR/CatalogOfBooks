using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BC.Entity
{
    public class AuthorEM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

		[Write(false)]
		public List<BookEM> Books { get; set; }
	}

}
