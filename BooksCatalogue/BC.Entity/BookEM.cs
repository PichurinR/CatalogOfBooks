using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BC.Entity
{
    public class BookEM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int Rating { get; set; }
        public DateTime DateOfPublication { get; set; }

        [Write(false)]
        public IEnumerable<AuthorEM> Authors { get; set; }
	}
}
