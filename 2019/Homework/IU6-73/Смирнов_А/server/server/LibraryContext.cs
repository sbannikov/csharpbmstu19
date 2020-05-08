using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
	class LibraryContext : DbContext
	{
		public LibraryContext()
			: base("DbConnection")
		{ }

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
	}
}


/*
 * class UserContext : DbContext
	{
		public UserContext()
			: base("DbConnection")
		{ }
		public DbSet<User> Users { get; set; }
		public DbSet<Car> Cars { get; set; }
	}
*/
